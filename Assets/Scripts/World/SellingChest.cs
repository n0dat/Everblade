using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellingChest : Collectable
{
    public AudioClip openAudioClip;
    public GameObject itemToDrop;
    public float howFar;
    public int price;

    public bool canBeOpened, hasCollided;

    void Start(){
        canBeOpened = false;
    }

    protected override void OnCollect(){
        if(Input.GetKeyDown(KeyCode.E)){
            if(player.GetComponent<playerRubies>().getRubies() >= price){
                Debug.Log("Player has bought from chest with " + price + " rubies");
                player.GetComponent<playerRubies>().removeRubies(price);
                AudioSource.PlayClipAtPoint(openAudioClip, transform.position);
                Debug.Log("Item bought");
                
                if(itemToDrop != null){
                    Vector3 spawnPoint = transform.position;
                    spawnPoint.y += howFar;
                    Object.Instantiate(itemToDrop, spawnPoint, Quaternion.identity);
                }// end of if spawnign item
            }// end of if checking if player has enough rubies
            else if (player.GetComponent<playerRubies>().getRubies() < price){
                Debug.Log("You can't buy you poor bitch");
            }
        }// end of if checking for key down
    }
    
}
