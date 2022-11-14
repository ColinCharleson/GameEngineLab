using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public Canvas editorUI;
    public Canvas gameUI;

    bool editorMode;
    // Start is called before the first frame update
    void Start()
    {
        editorMode = GetComponent<EditorManager>().editorMode;

        if(editorMode == false)
		{
            editorUI.enabled = false;
            gameUI.enabled = true;
		}
		else
        {
            editorUI.enabled = true;
            gameUI.enabled = false;
        }
    }

    public void ToggleEditorUI()
	{
        editorUI.enabled = !editorUI.enabled;
        gameUI.enabled = !gameUI.enabled;
    }
}
