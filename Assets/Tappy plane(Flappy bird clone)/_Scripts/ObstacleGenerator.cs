
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject obstacle;
    public Vector3 spawnPosition;

    private List<GameObject> obstacles;

	void Start ()
	{
	    obstacles = ObjectPool.Instance.Create(obstacle, 5);
        InvokeRepeating("CreateObstacle", 1f, 1.5f);
	}

    void CreateObstacle()
    {
        
        spawnPosition = new Vector3(8.5f,Random.Range(-1f, 4.5f),0);
        ObjectPool.Instance.Spawn(obstacles, spawnPosition, Quaternion.identity);
    }
}
