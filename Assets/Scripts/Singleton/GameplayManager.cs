using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{
	public static GameplayManager gameplay;

	public GameObject winPanel;
	public GameObject losePanel;

	public bool isWon = false;
	public bool isDead = false;
	private void Awake()
	{
		if (!gameplay)
		{
			gameplay = this;
		}

		winPanel.SetActive(false);
		losePanel.SetActive(false);
	}

	public void WinPanelToggle()
	{
		isWon = true;

		winPanel.SetActive(true);
	}

	public void LosePanelToggle()
	{
		isDead = true;

		losePanel.SetActive(true);
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
