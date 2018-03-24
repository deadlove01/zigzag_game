using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 1;


    private Rigidbody rigBody;
    void Awake()
    {
        rigBody = GetComponent<Rigidbody>();
    }

	// Use this for initialization
	void Start () {
		rigBody.velocity = new Vector3(moveSpeed, 0 ,0);
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0))
	    {
	        print("change direction");
	        SwitchDirection();
	    }
    }

    void FixedUpdate()
    {
      
    }

    void SwitchDirection()
    {
        if (rigBody.velocity.z > 0)
        {
            rigBody.velocity = new Vector3(moveSpeed, 0, 0);
        }else if (rigBody.velocity.x > 0)
        {
            rigBody.velocity = new Vector3(0, 0, moveSpeed);
        }
    }
}
