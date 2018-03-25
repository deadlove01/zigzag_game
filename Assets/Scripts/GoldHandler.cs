using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldHandler : MonoBehaviour
{

    [SerializeField] private float rotateSpeed = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Rotate();

	}


    void Rotate()
    {
        //transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        var rot = transform.eulerAngles;
        transform.rotation = Quaternion.Euler(new Vector3(0, rot.y + rotateSpeed * Time.deltaTime, 0));
    }
}
