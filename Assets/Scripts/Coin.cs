using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
	public int value = 1;
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			ScoreManager.instance.ChangeScore(value);
			Destroy(gameObject);
		}
	}
}
