using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Collidable {

    public Hotbar playerHotbar;
    public GameObject itemButton;
    public Item item;

    bool isFull = false;
    int slotCounter = 0;
    /*
     // No idea what these do tbh
    public ContactFilter2D filter;
	private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];

    protected virtual void Start(){
        boxCollider = GetComponent<BoxCollider2D>();
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

    /*
    *   OnCollide determines if the enemy is touching something
    *   if that something happens to have the name "Player"
    *   then the enemy is free to do damage to said player. 
    *   playerHealth was created and set in playerHealth.cs and the GetComponent<playerHealth> allows
    *   for it to be messed with and UpdateHealth is the actual function created
    *   in the .cs file that changes the health
    */

    protected override void OnCollide(Collider2D myCollider) {
        playerHotbar = GameObject.Find("PlayerHotbar").GetComponent<Hotbar>();

        for (int i = 0; i < playerHotbar.isUsed.Length; i++) {
            if (playerHotbar.isUsed[i]) {
                slotCounter++;
            }// end of if 
        }// end of for 

        if(slotCounter == 5)
            isFull = true;
        else
            isFull = false;

		if (myCollider.name == "Player") {
			if(!isFull) {
			   Debug.Log("Player has hit Item");
			   Destroy(gameObject);
			   PutInHotBar();
			   //PickUp();
			}// end of if 

			else 
				Debug.Log("HotBar is full\nis full: " + isFull + "\n");
		}
        slotCounter = 0;
    }// end of OnCollisionStay2D

    /*protected override void OnCollide(Collider2D myCollider){
        playerHotbar = GameObject.Find("PlayerHotbar").GetComponent<Hotbar>();
        if(myCollider.name == "Player"){
           Debug.Log("Player has hit Item");
           Destroy(gameObject);
           PutInHotBar();
           //PickUp();
        }// end of if 
    }// end of OnCollisionStay2D*/

    public void PickUp() {
        Debug.Log("picking up " + item.itemName);
        bool wasPickedUp = Inventory.instance.Add(item);
        playerHotbar = GameObject.Find("PlayerHotbar").GetComponent<Hotbar>();
		slotCounter--;
		/*
		for (int i = 0; i < playerHotbar.isUsed.Length; i++) {
			if (!playerHotbar.isUsed[i]) {
					playerHotbar.isUsed[i] = false;
					slotCounter--;
					return;
			}
		}
		*/
    }

	private void PutInHotBar() {
		playerHotbar = GameObject.Find("PlayerHotbar").GetComponent<Hotbar>();
		for (int i = 0; i < playerHotbar.isUsed.Length; i++) {
            if (!playerHotbar.isUsed[i]) {
                playerHotbar.isUsed[i] = true;
				//Will clone the first parameter and put it at the provided transofrm.
                Object.Instantiate(itemButton, GameObject.Find("Slot(" + (i + 1) + ")").transform, false);
				return;
            }
        }
    }

    /*private void PutInHotBar(){
        
        playerHotbar = GameObject.Find("PlayerHotbar").GetComponent<Hotbar>();

        if(playerHotbar.isUsed.Length == 5){
            Debug.Log("HotBar is full");
        }// end of first if

        else if (playerHotbar.isUsed.Length != 5){
            for (int i = 0; i < playerHotbar.isUsed.Length; i++){
                if (!playerHotbar.isUsed[i]) {
                    playerHotbar.isUsed[i] = true;
                    Object.Instantiate(itemButton, GameObject.Find("Slot(" + (i+ 1) + ")").transform, false);//Will clone the first parameter and put it at the provided transofrm.
                    break;
                }// end of inner if
            }// end of for 
        }// end of else 
    }// end of PutInHotBar*/
}
