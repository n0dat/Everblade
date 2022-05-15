using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//Whenever we attach this script to our gameObject, gameObject
//creates a new instance of the object defined by this class. 
//All components attached to our gameobject are initialized in the gameObject.
//The transform componenent is initialized in transform object as class Transform for example.
public class Player : MonoBehaviour {

	/*
	#region Singleton

    // doing this shoudl allow you to interact with one inventory at all times?? I have no idea, brackeys 
    public static Player playerInstance;

    void Awake(){
        if (playerInstance != null){
            Debug.LogWarning("more than one instance of inventory found!");
            return;
        }
        playerInstance = this;
    }
    #endregion
	*/

    private Animator anim;
    private BoxCollider2D boxCollider;
	//private Rigidbody2D rigidBody;
    private Vector3 moveDelta;
	public bool isSneaking;
	public Vector3 sneakSpeed;

    //Information returned about an object detected by a raycast in 2D physics.
    //When we call Physics2D.BoxCast(), The function returns a RayCastHIt2d which
    //has several fields containing information about the object hit by the ray.
    private RaycastHit2D hit;

	public float dmgReduction;
    
    //Start is called once upon game start.
    private void Start() {   
		//rigidBody = GetComponent<Rigidbody2D>();
    	boxCollider = GetComponent<BoxCollider2D>();
        anim = GameObject.Find("PlayerGFX").GetComponent<Animator>(); //Attach to our player Animator.
        Physics2D.queriesStartInColliders = false;
		isSneaking = false;
		sneakSpeed = new Vector3(0.5f, 0.5f, 0);
        //DontDestroyOnLoad(gameObject);
    }

	public float getDmgReduction(){
		return dmgReduction;
	}

	public void setDmgReduction(float mod){
		dmgReduction = mod;
	}

	void Update() {
		if(EventSystem.current.IsPointerOverGameObject()){
			return;
		}
	}
    
    
    //FixedUpdate function is called once every frame.
    private void FixedUpdate() {
    	
		//if (Input.GetKeyUp(KeyCode.Z)) {
		//	isSneaking = false;
		//	transform.GetChild(3).GetComponent<Animator>().enabled = true;
		//}
		if (Input.GetKey(KeyCode.LeftControl)) {
			isSneaking = true;
			transform.GetChild(3).GetComponent<Animator>().enabled = false;
		}
		else {
			isSneaking = false;
			transform.GetChild(3).GetComponent<Animator>().enabled = true;
		}
		
	
    	float x = Input.GetAxisRaw("Horizontal");
    	float y = Input.GetAxisRaw("Vertical");

        
        if (x == 0 && y == 0)
            anim.SetBool("Stopped", true);
        else
            anim.SetBool("Stopped", false);
        
    	//Debug.Log(x);
    	//Debug.Log(y);

    	//Reset move Delta
    	moveDelta = new Vector3(x, y, 0);

    	// Swap sprite direction, whether you're going right or left.
        	if (moveDelta.x > 0)
        		transform.localScale = Vector3.one;
        	else if (moveDelta.x < 0)
        		transform.localScale = new Vector3(-1, 1, 1);
       
    	//Make sure we can move in this direction by casting a bos there first. If the box returns null, we are free to move.
    	//A BoxCast is conceptually like dragging a box through the Scene in a particular direction. Any object making contact with the box can be detected and reported.
    	hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Actor","Blocking", "Enemy"));
        if (hit.collider == null) {
    		//Make this thing move
    		//Debug.Log("in y");
			//rigidBody.AddForce(moveDelta * Time.deltaTime, ForceMode2D.Impulse);
			if (isSneaking)
    			transform.Translate(0, moveDelta.y * Time.deltaTime * sneakSpeed.y, 0);
			else
				transform.Translate(0, moveDelta.y * Time.deltaTime, 0);

    	}
    	
    	//Needed to change the layer which we have our character, because we were colliding with ourself.
    	//Instead of having to do that though, We can instead change the field quieries start in colliders to false, so that if the ray starts in a collider, it wont return the collider that it starts in. I already did this.
    	//Same thing, but in the X direction now.
    	hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Actor","Blocking", "Enemy"));
    	if (hit.collider == null) {
    		//Debug.Log("in x");
    		//Make this thing move
			//rigidBody.AddForce(moveDelta * Time.deltaTime, ForceMode2D.Impulse);
			if (isSneaking)
    			transform.Translate(moveDelta.x * Time.deltaTime * sneakSpeed.x, 0, 0);
			else
				transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
    	}
    }
}
