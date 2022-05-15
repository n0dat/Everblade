/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{

	//Where we want to go
	public Transform target;
	//How fast we want to go
	public float speed = 2;
	//How close we want to be to our next waypoint before moving onto the next one.
	public float waypointDistance = 2;

	private Path path;
	int currentWaypoint = 0;
	bool reachedEndOfPath = false;

	Seeker seeker;

	//For controlling our current position. Defaulted to this gameObjects transform component.
	Transform currentTransform;

    // Start is called before the first frame update
    void Start()
    {
        seeker = gameObject.getComponent<Seeker>();
        currentTransform = transform;

        //StartPath function in Seeker class calculates a path. Take param Vector3 Start, Vector 3End, and a function that you can subscribe to an event when that path is completed being calculated.
        seeker.StartPath(currentTransform.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
    	if (!p.error)
    	{
    		path = p;
    		currentWaypoint = 0;
    	}

    }

    // Update is called once per frame
    void Update()
    {
        if (path == null)
        	return;

        //When our current waypoint is an integer greater than the total number of waypoints in our path, it is completed.
        if (currentWaypoint >= path.vectorPath.Count)
        {
        	reachedEndOfPath = true;
        	return;
        }
        else
        {
        	reachedEndOfPath = false;
        }

        //The actual path to follow is stored in a List of Vector3 Objects called vectorPath in the path class.

        Vector3 direction = path.vectorPath[currentWaypoint] - currentTransform.position;
    }
}
*/
