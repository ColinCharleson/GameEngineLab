using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyButton : MonoBehaviour
{
    private EnemyFactory factory;

    private EditorManager editor;

    TextMeshProUGUI btnText;

    Subject subject = new Subject();
    // Start is called before the first frame update
    void Start()
    {
        factory = GameObject.Find("GameManager").GetComponent<EnemyFactory>();

        editor = EditorManager.instance;

        btnText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnClickSpawn()
	{
        switch (btnText.text)
		{
            case "bee":
                editor.item = factory.GetEnemy("bee").Create(factory.prefab1);
                break;
            case "monster":
                editor.item = factory.GetEnemy("monster").Create(factory.prefab2);
                break;
            case "spike 1":
                editor.item = factory.GetEnemy("spike 1").Create(factory.spikePrefab1);
                SpikeBall spike1 = new SpikeBall(editor.item, new GreenMat());
                subject.AddObserver(spike1);
                break;
            case "spike 2":
                editor.item = factory.GetEnemy("spike 2").Create(factory.spikePrefab2);
                SpikeBall spike2 = new SpikeBall(editor.item, new YellowMat());
                subject.AddObserver(spike2);
                break;
            default:
                break;
		}

        subject.Notify();
        editor.instantiated = true;
	}
}
