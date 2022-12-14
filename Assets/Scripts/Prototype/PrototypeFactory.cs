using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PrototypeFactory : MonoBehaviour
{
    public List<CollectableData> allData;

    public GameObject buttonPanel;
    public GameObject buttonPrefab;

    private EditorManager editor;

    Coin coinPrototype;
    BlueGem bluePrototype;
    RedGem redPrototype;
    GreenGem greenPrototype;
    Heart heartPrototype;
    Key keyPrototype;
    // Start is called before the first frame update
    void Start()
    {
        editor = EditorManager.instance;

        coinPrototype = new Coin(allData[0]._prefab, allData[0]._score);
        bluePrototype = new BlueGem(allData[1]._prefab, allData[1]._score);
        greenPrototype = new GreenGem(allData[2]._prefab, allData[2]._score);
        redPrototype = new RedGem(allData[3]._prefab, allData[3]._score);
        heartPrototype = new Heart(allData[4]._prefab, allData[4]._heal);
        keyPrototype = new Key(allData[5]._prefab);

        for(int i = 0; i < allData.Count; i++)
		{
            var button = Instantiate(buttonPrefab);
            button.transform.SetParent(buttonPanel.transform, false);
            button.gameObject.name = allData[i]._name + " Button";
            button.GetComponentInChildren<TextMeshProUGUI>().text = allData[i]._name;
            button.GetComponent<Button>().onClick.AddListener(delegate { Spawner(button); });
		}
    }
    void Spawner(GameObject button)
	{
        var btn = button.GetComponentInChildren<TextMeshProUGUI>();

        switch(btn.text)
		{
            case "Coin":
                editor.item = coinPrototype.Clone().Spawn();
                break;
            case "Green Gem":
                editor.item = greenPrototype.Clone().Spawn();
                break;
            case "Blue Gem":
                editor.item = bluePrototype.Clone().Spawn();
                break;
            case "Red Gem":
                editor.item = redPrototype.Clone().Spawn();
                break;
            case "Heart":
                editor.item = heartPrototype.Clone().Spawn();
                break;
            case "Key":
                editor.item = keyPrototype.Clone().Spawn();
                break;

            default:
                break;

		}

        editor.instantiated = true;
	}
    // Update is called once per frame
    void Update()
    {
        
    }
}
