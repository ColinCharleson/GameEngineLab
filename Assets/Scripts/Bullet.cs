using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
	private void OnCollisionEnter(Collision other)
	{
		gameObject.SetActive(false);

		if (other.collider.tag == "Player")
		{
			if (other.gameObject.GetComponent<PlayerController>().health >= 2)
			{
				other.gameObject.GetComponent<PlayerController>().health -= 1;
			}
			else
			{
				Scene scene = SceneManager.GetActiveScene();
				SceneManager.LoadScene(scene.name);
			}

		}
		else if (other.collider.tag == "Enemy")
		{
			Destroy(other.gameObject);
		}
	}
}
