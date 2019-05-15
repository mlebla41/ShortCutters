using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {
    public Transform player;
    public float speed;
    Vector2[] path;
    int targetIndex;

    public void OnPathFound(Vector2[] newPath, bool pathSuccess)
    {
        if (pathSuccess)
        {
            path = newPath;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }
    void FindPath()
    {
        PathRequestController.RequestPath(transform.position, player.position, OnPathFound);
    }

    IEnumerator FollowPath()
    {
        Vector2 currentWaypoint = path[0];

        targetIndex = 0;

        while(true)
        {
            if ((Vector2)transform.position == currentWaypoint)
            {
                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }
            transform.position = Vector2.MoveTowards(transform.position, currentWaypoint,Time.deltaTime * speed);
            yield return null;
        }
    }

	
	void LateUpdate () {
		FindPath();
	}
}
