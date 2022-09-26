using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EditorManager : MonoBehaviour
{
    PlayerAction inputAction;

    public Camera mainCamera;
    public Camera editorCamera;

    public bool editorMode = false;
    public bool instantiated = false;

    public GameObject prefab1;
    public GameObject prefab2;

    GameObject item;
    private void OnEnable()
    {
        inputAction.Editor.Enable();
    }
    private void OnDisable()
    {
        inputAction.Editor.Disable();
    }
    // Start is called before the first frame update
    void Awake()
    {
        inputAction = new PlayerAction();

        inputAction.Editor.EnableEditor.performed += cntxt => SwitchCamera();

        inputAction.Editor.AddItem1.performed += cntxt => AddItem(1);
        inputAction.Editor.AddItem2.performed += cntxt => AddItem(2);
        inputAction.Editor.DropItem.performed += cntxt => DropItem();

        mainCamera.enabled = true;
        editorCamera.enabled = false;
    }

    void SwitchCamera()
    {
        mainCamera.enabled = !mainCamera.enabled;
        editorCamera.enabled = !editorCamera.enabled;
    }
    void AddItem(int itemId)
    {
        if(editorMode && instantiated)
            switch(itemId)
			{
                case 1:
                    item = Instantiate(prefab1);
                    break;
                case 2:
                    item = Instantiate(prefab2);
                    break;
                default:
                    break;
			}
        instantiated = true;
    }
    void DropItem()
    {

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
    }
}
