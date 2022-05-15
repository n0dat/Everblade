using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidable : MonoBehaviour {

	public ContactFilter2D filter;
	private BoxCollider2D boxCollider;
	private Collider2D[] hits = new Collider2D[10]; //Parent class for all collidder types used in 2d gameplay
    protected float timer;
    protected GameObject player;

	// Start is called before the first frame update
    protected virtual void Start() {
        boxCollider = GetComponent<BoxCollider2D>(); //Returns the boxcollider attached to this gameObject
        timer = 0;
    }

    public void Awake() {
        player = GameObject.Find("Player");
        boxCollider = GetComponent<BoxCollider2D>();
    }//end Awake()

    // Update is called once per frame
    protected virtual void Update() {
        //Timer stuff.
        timer += Time.deltaTime;
        
        //collision stuff
        boxCollider.OverlapCollider(filter, hits); //returns all colliders that are overlapping this collider, and puts references in hits.

        for (int i = 0; i < hits.Length; i++) {
        	if (hits[i] != null) {
        		OnCollide(hits[i]);
        		//Need to clean array
        		hits[i] = null;
        	}	
        }

    }

    //This will be called anytime something is collided with. Will use inheritence to customize depending on touched object.
    protected virtual void OnCollide(Collider2D myCollider) {
    	Debug.Log(myCollider.name);
    }
}
