using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropDownHandler : MonoBehaviour
{
    TMP_Dropdown dropdown;

    public List<GameObject> allPanels;
        
        // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponent<TMP_Dropdown>();

        DeactivateAllPanels();
        DropDownItemSelected(dropdown);

        dropdown.onValueChanged.AddListener(delegate { DropDownItemSelected(dropdown); });
    }

    public void DropDownItemSelected(TMP_Dropdown dropdown)
	{
        int index = dropdown.value;

        switch (index)
		{
            case 0:
                DeactivateAllPanels();
                allPanels[0].SetActive(true);
                break;

            case 1:
                DeactivateAllPanels();
                allPanels[1].SetActive(true);
                break;

            case 2:
                DeactivateAllPanels();
                allPanels[2].SetActive(true);
                break;

			default:
                break;
        }
	}
    // Update is called once per frame
    void DeactivateAllPanels()
    {
        foreach(var panel in allPanels)
		{
            panel.SetActive(false);
		}
    }
}
