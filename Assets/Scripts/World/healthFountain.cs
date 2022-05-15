using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*   The following was meant to be used for when a player makes contact with a 
*   health fountain which should be found in game
*   nothing has actually been set since as of right now, FS does not know 
*   how to add sprites nor how the collision works, but if someone else comes in 
*   the code below works fairly similar to the enemyDmg.cs file. If the fountain collides 
*   with something and the name of that someting ends up being "Player" then it will
*   send a positive health modifier which increases the players health
*/

public class healthFountain : MonoBehaviour
{

    //private playerHealth ph = playerHealth.playerHealthInstance;
    [SerializeField] private float canHeal = 1f;
    SpriteRenderer rend;

    GameObject player;
    playerHealth ph;

    /*  
    *   variables will be used accordingly, SField allows for the variable
    *   to be seen and probably set in unity interface
    *   canAttack is used to allow the enemy to attack in intervals otherwise the enemy would attack 
    *   the whole time the player is touching them, which would kill the player in a few seconds
    */ 

    // No idea what these do tbh
    public ContactFilter2D filter;
	private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];
    public Sprite emptyHF;

    //public Player player;

    //float currentH;
    //float maxH;

    protected virtual void Start(){
        player = GameObject.Find("Player");
        ph = player.GetComponent<playerHealth>();

        boxCollider = GetComponent<BoxCollider2D>();
        rend = GetComponent<SpriteRenderer>();
    }// end of Start()

    protected virtual void Update(){
        
        //collision stuff
        boxCollider.OverlapCollider(filter, hits); //returns all colliders that are overlapping this collider, and puts references in hits.

        for (int i = 0; i < hits.Length; i++){
            if (hits[i] != null) {
        		OnCollide(hits[i]);
        		//Need to clean array
        		hits[i] = null;
        	}// end of if 	
        }// end of for
        
    }// end of update()

    [SerializeField] private float healthMod = 50f;

     protected virtual void OnCollide(Collider2D myCollider){

        //currentH = player.gameObject.GetComponent<playerHealth>().getHealth();
        //maxH = player.gameObject.GetComponent<playerHealth>().getMaxHealth();

        if(myCollider.name == "Player" && canHeal != 0 && ph.health != ph.maxHealth ){
            Debug.Log("Player has touched me...");
            myCollider.gameObject.GetComponent<playerHealth>().UpdateHealth(+healthMod);
            canHeal = 0;
            Debug.Log("50 Hp added...");
	
            if(canHeal == 0){
                GetComponent<SpriteRenderer>().sprite = emptyHF;
            }// end of inner if
        }// end of if 

        /*if(myCollider.name == "Player" && canHeal != 0){
            Debug.Log("Player has touched me...");
            myCollider.gameObject.GetComponent<playerHealth>().UpdateHealth(+healthMod);
            canHeal = 0;
            Debug.Log("50 Hp added...");
	
            if(canHeal == 0){
                GetComponent<SpriteRenderer>().sprite = emptyHF;
            }// end of inner if
        }// end of if */

    }// end of OnCollisionStay2D
}// end of class healthFountain
