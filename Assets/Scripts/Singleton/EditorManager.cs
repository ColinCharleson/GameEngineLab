using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

	public GameObject item;

	public InputField yInput;
	public float yPos = 0;

	ICommand command;

	UIManager ui;

	public float unit = 10;
	public Vector3 defaultPos;

	// Start is called before the first frame update
	void Start()
	{
		inputAction = PlayerInputController.controller.inputAction;

		inputAction.Editor.EnableEditor.performed += cntxt => SwitchCamera();

		inputAction.Editor.DropItem.performed += cntxt => DropItem();

		mainCamera.enabled = true;
		editorCamera.enabled = false;

		ui = GetComponent<UIManager>();
	}
	private void Awake()
	{
		defaultPos = editorCamera.transform.position;
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
	void DropItem()
	{
		if (editorMode && instantiated)
		{
			if (item.GetComponent<Rigidbody>())
			{
				item.GetComponent<Rigidbody>().useGravity = true;
			}
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
		else if (GameplayManager.gameplay.isWon || GameplayManager.gameplay.isDead)
		{
			Time.timeScale = 0;
			Cursor.lockState = CursorLockMode.None;
		}
		else
		{
			editorMode = false;
			Time.timeScale = 1;
			Cursor.lockState = CursorLockMode.Locked;
		}

		if (instantiated && editorMode)
		{
			yPos = int.Parse(yInput.text);
			mousePos = Mouse.current.position.ReadValue();
			mousePos = new Vector3(mousePos.x, mousePos.y, editorCamera.transform.position.y - yPos);

			item.transform.position = editorCamera.ScreenToWorldPoint(mousePos);

		}
	}

	public void MoveCameraPos(string direction)
	{
		switch (direction)
		{
			case "Up":
				editorCamera.transform.Translate(transform.forward * unit, Space.World);
				break;
			case "Down":
				editorCamera.transform.Translate(transform.forward * -unit, Space.World);
				break;
			case "Left":
				editorCamera.transform.Translate(transform.right * -unit, Space.World);
				break;
			case "Right":
				editorCamera.transform.Translate(transform.right * unit, Space.World);
				break;
			case "Reset":
				editorCamera.transform.position = defaultPos;
				break;
			default:
				break;
		}
	}
}
