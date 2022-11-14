using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : CharacterStats
{
	public Animator animator;

	public override void Die()
	{
		base.Die();

		animator.SetTrigger("isDead");

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
