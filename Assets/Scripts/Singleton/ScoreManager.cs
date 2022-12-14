using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	public static ScoreManager instance;

	public int score;
	public Text scoreText;
	private void Awake()
	{
		if(!instance)
		{
			instance = this;
		}
	}

	public void ChangeScore(int coinValue)
	{
		score += coinValue;
		Debug.Log(score);
		scoreText.text = ScoreManager.instance.score.ToString();
	}
}
