using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{

    public Transform ballTarget;
    public bool isGameOver = false;
    [SerializeField]
    private float smoothRate = 1.5f;


    private Vector3 distance;
	// Use this for initialization
	void Start ()
	{
	    isGameOver = false;
        distance = ballTarget.position - transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (!isGameOver)
	    {
	        FollowTarget();
        }
	    

	}


    void FollowTarget()
    {
        var pos = transform.position;
        var newDist = ballTarget.position - distance;
        var newPos = Vector3.Lerp(pos, newDist, smoothRate);
        transform.position = newPos;
    }
}
