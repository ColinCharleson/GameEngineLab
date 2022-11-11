using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
	public int score = 1;
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			ScoreManager.instance.ChangeScore(score);
			Destroy(gameObject);
		}
	}
}
