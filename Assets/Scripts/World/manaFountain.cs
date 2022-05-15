using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manaFountain : MonoBehaviour
{
    [SerializeField] private float canRestore = 1f;
    SpriteRenderer rend;

    GameObject player;
    playerMana pm;

    //public Player player;

    //float currentM;
    //float maxM;

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
    public Sprite emptyMF;

    protected virtual void Start(){

        player = GameObject.Find("Player");
        pm = player.GetComponent<playerMana>();

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

    [SerializeField] private float manaMod = 50f;

     protected virtual void OnCollide(Collider2D myCollider){

        //currentM = player.gameObject.GetComponent<playerMana>().GetMana();
        //maxM = player.gameObject.GetComponent<playerMana>().GetmaxMana();

        if(myCollider.name == "Player" && canRestore != 0 && pm.mana != pm.maxMana ){
            Debug.Log("Player has touched me...");
            myCollider.gameObject.GetComponent<playerMana>().UpdateMana(manaMod);
            canRestore = 0;
            Debug.Log("50 Mp added...");
            
            if(canRestore == 0){
                GetComponent<SpriteRenderer>().sprite = emptyMF;
            }// end of inner if
        }// end of if 

        /*if(myCollider.name == "Player" && canRestore != 0){
            Debug.Log("Player has touched me...");
            myCollider.gameObject.GetComponent<playerMana>().UpdateMana(manaMod);
            canRestore = 0;
            Debug.Log("50 Mp added...");
            
            if(canRestore == 0){
                GetComponent<SpriteRenderer>().sprite = emptyMF;
            }// end of inner if
        }// end of if*/

    }// end of OnCollisionStay2D
}
