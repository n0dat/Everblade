using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour {

	//Where we want to go
	public Transform target;
	//How fast we want to go
	public float speed;
	//How close we want to be to our next waypoint before moving onto the next one.
	public float nextWaypointDistance = 0;
	//Public direction we want our enemy to move.
	public Vector3 direction;
	//How close we want to be to our target (total distance) before we call OnReachingEnd()
	public float stopDistanceFromTarget;
	//Distance before the AI begins pursuit.
	public float distanceBeforePursuit;
	//The path that is generated from our seeker.
	private Path path;
	//The current waypoint that our ai is at along the path.
	private int currentWaypoint = 0;
	//The animation on our enemyGFX
	private Animator anim;
	//Ray that will be cast for collision.
	private RaycastHit2D hit;
	private RaycastHit2D hit2;
	//The boxcollider used by the AI.
	private BoxCollider2D boxCollider;
	//Actual distance from target.
	private float actualDistanceFromTarget;

	Seeker seeker;

	public void setStopDistance(float distance){
		stopDistanceFromTarget = distance;
	}

    // Start is called before the first frame update
    void Awake() {
		if(gameObject.name == "PlayerSummon(Clone)")
			target = FindClosestEnemy().transform;
		else
    		target = GameObject.Find("Player").transform;
    }
    void Start() {
        seeker = gameObject.GetComponent<Seeker>();
        anim = transform.GetChild(2).gameObject.GetComponent<Animator>(); //Grab the animation component on the enemy GFX object.
        //StartPath function in Seeker class calculates a path. Take param Vector3 Start, Vector 3End, and a function that you can subscribe to an event when that path is completed being calculated.
        seeker.StartPath(transform.position, target.position, OnPathComplete);
        boxCollider = transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>();
    }

	//The generated path will be passed to this function
    void OnPathComplete(Path p) {
    	if (!p.error) {
    		path = p; //We put the generated path in this variable, which we can then access.
    		currentWaypoint = 1;
    		return;
    	}
    	path = p; //We put the generated path in this variable, which we can then access.
    		currentWaypoint = 1;
    		return;
    }

    // Update is called once per frame

	 public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    void Update() {
		try{
			if(gameObject.name == "PlayerSummon(Clone)")
				target = FindClosestEnemy().transform;
		}
		catch(NullReferenceException e){
			Destroy(gameObject);
		} 

		actualDistanceFromTarget = Mathf.Abs(Vector3.Distance(transform.position, target.position));
		
		if (actualDistanceFromTarget > distanceBeforePursuit)
			return;
		
        if (path == null){
        	seeker.StartPath(transform.position, target.position, OnPathComplete);
        	return;
        }

        seeker.StartPath(transform.position, target.position, OnPathComplete);

        if (path.GetTotalLength() <= stopDistanceFromTarget || path.GetTotalLength() > distanceBeforePursuit) 
        	return;

        //When our current waypoint is an integer greater than the total number of waypoints in our path, it is completed.
        if (currentWaypoint >= path.vectorPath.Count)
        	//reachedEndOfPath = true;
        	return;
        else
        	//reachedEndOfPath = false;

        //The actual path to follow is stored in a List of Vector3 Objects called vectorPath in the path class.
        //This normalized vector will point in the direction we wish to go.
        direction = (path.vectorPath[currentWaypoint] - transform.position).normalized;

        //Check for player to prevent clipping.

        hit = Physics2D.BoxCast(new Vector2(transform.position.x, transform.position.y), boxCollider.size, 0, direction, Math.Abs(Vector3.Distance(Vector3.zero, direction*speed*Time.deltaTime)), LayerMask.GetMask("Actor"));
        hit2 = Physics2D.BoxCast(new Vector2(transform.position.x, transform.position.y), boxCollider.size, 0, direction, Math.Abs(Vector3.Distance(Vector3.zero, direction*speed*Time.deltaTime)), LayerMask.GetMask("Blocking"));
        if (hit.collider == null && hit2.collider == null) {
	        transform.Translate(direction*speed*Time.deltaTime);
	        
	        float distance = Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]);

	        if (distance > 0)
	        	anim.SetBool("isMoving", true);
	        else
	        	anim.SetBool("isMoving", false);

	        //Debug.Log("Distance: " + distance);

	        if (distance <= 0.01)
	        	currentWaypoint++;
        }
    }
}
