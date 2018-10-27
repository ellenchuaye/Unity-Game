using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //public PlayerController thePlayer;

    //private Vector3 lastPlayerPosition;
    //private float distanceToMove;

    public float speed;
    private float moveDistanceStore;
    private float distanceToMove;
    private bool repeat;
    public float speedMultiplier;
    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneStore;
    private float speedMilestoneCount;
    private float speedMilestoneCountStore;
    private float distanceToMoveTemp;

    //private float height;

   // public Camera cam;
	// Use this for initialization
	void Start () {
        //  thePlayer = FindObjectOfType<PlayerController>();
        //  lastPlayerPosition = thePlayer.transform.position;
        distanceToMove = speed * Time.deltaTime;
        moveDistanceStore = distanceToMove;
        speedMilestoneCount = speedIncreaseMilestone;
        //startTime = Time.time;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;
        // cam = GetComponent<Camera>();
       // height = Screen.height;



    }
	
	// Update is called once per frame
	void Update () {

        // distanceToMove = thePlayer.transform.position.y - lastPlayerPosition.y;
        //if (distanceToMove > 0)
        //{

        if (transform.position.y > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone *= speedMultiplier;
            distanceToMove *= speedMultiplier;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y + distanceToMove, transform.position.z);
        
        
        
        //}
        //lastPlayerPosition = thePlayer.transform.position;
	}
    /*public float getHeight()
    {
        float height = 2f * cam.orthographicSize;
        return height;
    }*/

    public void reset()
    {
        // speed = moveSpeedStore;
        distanceToMove = moveDistanceStore;
        speedMilestoneCount = speedMilestoneCountStore;
        speedIncreaseMilestone = speedIncreaseMilestoneStore;
        
    }

    public void stop()
    {
        distanceToMoveTemp = distanceToMove;
        distanceToMove = 0;
    }

    public void resume()
    {
        distanceToMove = distanceToMoveTemp;
    }
}
