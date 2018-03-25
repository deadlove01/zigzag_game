using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawnManager : MonoBehaviour
{

    public GameObject floorPrefab;
    public GameObject goldPrefab;
    public int goldCreatingPercent = 15;
    public bool isGameOver = false;

    private Vector3 lastPos;

    [SerializeField]
    private int floorSize =2;

    [SerializeField]
    private int numOfStartFloor = 20;

    // Use this for initialization
    void Start ()
	{
	    isGameOver = false;
        lastPos = transform.position;

	    for (int i = 0; i < numOfStartFloor; i++)
	    {
	        SpawnFloors();

	    }

        
	}


	
	// Update is called once per frame
	void Update () {

	    if (isGameOver)
	    {
	        CancelInvoke("SpawnFloors");
	    }

	}


    void SpawnFloors()
    {
        int rand = Random.Range(0, 8);
        SpawnFloor(rand >= 4);
    }

    void SpawnFloor(bool isZDirection)
    {
        Vector3 pos = lastPos;
        if (isZDirection)
        {
            pos.z += floorSize;
        }
        else
        {
            pos.x += floorSize;
        }
       
        lastPos = pos;
        Instantiate(floorPrefab, pos, Quaternion.identity);

        int rand = Random.Range(0, 99);
        if (rand < goldCreatingPercent)
        {
            Instantiate(goldPrefab, new Vector3(pos.x, pos.y + 1, pos.z), Quaternion.identity);
        }
    }


    public void StartSpawnFloors()
    {
        InvokeRepeating("SpawnFloors", 3, 0.2f);
    }
}
