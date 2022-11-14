using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public List<GameObject> movePoints;
    int currentMovePointIndex=0;
    Vector3 targetPos;

    public float speed = 15f;
    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(movePoints[currentMovePointIndex].transform.position.z - transform.position.z) < .1f)
		{
            currentMovePointIndex++;

            if (currentMovePointIndex >= movePoints.Count)
                currentMovePointIndex = 0;
		}
        targetPos = new Vector3(transform.position.x, transform.position.y, movePoints[currentMovePointIndex].transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.name == "Player")
		{
            collision.gameObject.transform.SetParent(transform);
		}
	}
	private void OnCollisionExit(Collision collision)
    {
        collision.gameObject.transform.SetParent(null);
    }
}
