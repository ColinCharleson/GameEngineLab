using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
	public int score;
	public int heal;
	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			if(score == 0 && heal == 0)
			{
				GameplayManager.gameplay.WinPanelToggle();
			}

			if(score != 0)
				ScoreManager.instance.ChangeScore(score);

			if (heal != 0)
				PlayerManager.instance.player.GetComponent<CharacterStats>().RecoverHealth(heal);

			Destroy(gameObject);
		}
	}
}
