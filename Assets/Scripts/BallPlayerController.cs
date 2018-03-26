using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPlayerController : MonoBehaviour
{
    public GameObject goldEffectPrefab;
    public FloorSpawnManager floorSpawnManager;
    [SerializeField] private float moveSpeed = 1;

    private bool isStarted = false;
    private bool isGameover = false;
    private Rigidbody rigBody;
 
    void Awake()
    {
        rigBody = GetComponent<Rigidbody>();
    }

	// Use this for initialization
	void Start () {
		
	    isStarted = false;
	    isGameover = false;
	}
	
	// Update is called once per frame
	void Update () {

	    if (!isStarted)
	    {
	        if (Input.GetMouseButtonDown(0))
	        {
	            rigBody.velocity = new Vector3(moveSpeed, 0, 0);
	            isStarted = true;
                floorSpawnManager.StartSpawnFloors();
                GameManager.Instance.StartGame();
	        }
        }
	    else
	    {
	        CheckingFallingDown();
            if (Input.GetMouseButtonDown(0) && !isGameover)
	        {
	            SwitchDirection();
	        }
        }
       
	   
    }

    void FixedUpdate()
    {
      
    }


    void CheckingFallingDown()
    {
        if (!Physics.Raycast(transform.position, Vector3.down, 1F))
        {
            isGameover = true;
            rigBody.velocity = new Vector3(0, Physics.gravity.y, 0);

            // update camera
            Camera.main.GetComponent<FollowingCamera>().isGameOver = true;
            floorSpawnManager.isGameOver = true;
            GameManager.Instance.EndGame();
        }
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


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Gold")
        {
            Destroy(col.gameObject);
            Instantiate(goldEffectPrefab, col.gameObject.transform.position, Quaternion.identity);
            var point = GameManager.Instance.goldPoint;
            ScoreManager.Instance.AddMoreScore(point);
            FloatingTextManager.Instance.CreateFloatingText("+"+point, col.transform);
        }
    }
}
