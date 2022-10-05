using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EditorManager : MonoBehaviour
{
    public static EditorManager instance;

    PlayerAction inputAction;

    public Camera mainCamera;
    public Camera editorCamera;

    public bool editorMode = false;
    public bool instantiated = false;

    Vector3 mousePos;

    public GameObject prefab1;
    public GameObject prefab2;

    Subject subject = new Subject();

    public GameObject item;

    ICommand command;

    UIManager ui;
    // Start is called before the first frame update
    void Start()
    {
        inputAction = PlayerInputController.controller.inputAction;

        inputAction.Editor.EnableEditor.performed += cntxt => SwitchCamera();

        inputAction.Editor.AddItem1.performed += cntxt => AddItem(1);
        inputAction.Editor.AddItem2.performed += cntxt => AddItem(2);
        inputAction.Editor.DropItem.performed += cntxt => DropItem();

        mainCamera.enabled = true;
        editorCamera.enabled = false;

        ui = GetComponent<UIManager>();
    }
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }
    void SwitchCamera()
    {
        mainCamera.enabled = !mainCamera.enabled;
        editorCamera.enabled = !editorCamera.enabled;

        ui.ToggleEditorUI();
    }
    void AddItem(int itemId)
    {
        if(editorMode && !instantiated)
            switch(itemId)
			{
                case 1:
                    item = Instantiate(prefab1);

                    SpikeBall spike1 = new SpikeBall(item, new GreenMat());
                    subject.AddObserver(spike1);
                    break;
                case 2:
                    item = Instantiate(prefab2);

                    SpikeBall spike2 = new SpikeBall(item, new YellowMat());
                    subject.AddObserver(spike2);
                    break;
                default:
                    break;
            }
        subject.Notify();
        instantiated = true;
    }
    void DropItem()
    {
        if (editorMode && instantiated)
        {
            item.GetComponent<Rigidbody>().useGravity = true;
            item.GetComponent<Collider>().enabled = true;

            command = new PlaceItemCommand(item.transform.position, item.transform);
            CommandInvoker.AddCommand(command);

            instantiated = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (mainCamera.enabled == false && editorCamera.enabled == true)
        {
            editorMode = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            editorMode = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if(instantiated && editorMode)
		{
            mousePos = Mouse.current.position.ReadValue();
            mousePos = new Vector3(mousePos.x, mousePos.y, 10f);

            item.transform.position = editorCamera.ScreenToWorldPoint(mousePos);

		}
    }
}
