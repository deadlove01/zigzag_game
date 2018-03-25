using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorHandler : MonoBehaviour
{

    private int destroyTime = 2;
    private float fallDownTime = 0.5f;

    // Use this for initialization
    void Start () {
		
	}

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Ball")
        {
            Invoke("FallDownAndDestroy", fallDownTime);
        }
    }


    void FallDownAndDestroy()
    {
        var rig = GetComponentInParent<Rigidbody>();
        rig.isKinematic = false;
        rig.useGravity = true;
        Destroy(gameObject, destroyTime);
    }
}
