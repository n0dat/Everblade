using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

/*
*   I'll put this in the healthBar.cs file as well, but you have to attach the healthBar to the playerHealth Script component that is attached to the player.
*   So under player there is a playerHealth script component. Go to this and drag the healthBar object to the hb part of the script that is shown. If you don't do this, 
*   you're more than likely to get a NullReferenceExeption which is a bitch and a half 
*/

public class playerHealth : MonoBehaviour{

    #region Singleton

    // doing this shoudl allow you to interact with one inventory at all times?? I have no idea, brackeys 
    public static playerHealth playerHealthInstance;

    void Awake(){
        if (playerHealthInstance != null){
            Debug.LogWarning("more than one instance of inventory found!");
            return;
        }
        playerHealthInstance = this;
    }
    #endregion

    public float health = 1f;
    
    //a healthBar obj is created so that the healthBar in game 
    //will move according to the actual players health
    public healthBar hb;

    //private playerHealth ph = playerHealth.playerHealthInstance;
    
    
    // Audio clip for taking damage
    public AudioClip damageAudioClip;

    // the serializeField should allow for the heealth to be messed 
    // with in the unity editor but still be private
    public float maxHealth = 100f;

    // setMaxHealth and follwoign SetHealth are function found in healthBar.cs
    // what they do will be explained in said file 
    private void Start(){
        health = maxHealth;
        hb.setMaxHealth(maxHealth);
    }// end of Start 

    /*  
    *   this should allow you to add health, so say you pick up a pot or fountain 
    *   you don't want the player to have more health than they should or decrease 
    *   health if you should get some kind of dmg
    */ 

    public void UpdateMaxHealth(float mod){
        hb.UpdateMaxHealth(maxHealth + mod);
        //ph.UpdateHealth(1);
        maxHealth += mod;
    }

    public float getHealth(){
        return health;
    }

    public float getMaxHealth(){
        return maxHealth;
    }

    public void UpdateHealth(float mod) {
        health += mod;
        
        if (mod < 0) {
            AudioSource.PlayClipAtPoint(damageAudioClip, transform.position);
			CameraShaker.Instance.ShakeOnce(1f,1f, .1f, .3f);
        }
        // doesn't allow for the player to have more health than allowed
        if(health > maxHealth){ 
            health = maxHealth;
            hb.SetHealth(health);
        }// end of if 

        /*
        *   setting the health to zero allows the player to die without the health bar gong further
        *   back than it needs to. Meaning if the health goees into the negative because of a sufficiently 
        *   storng attack from an enemy, it won't acutally become negative and will insteead just default to zero 
        */

        else if(health <= 0) {
            health = 0f;
            hb.SetHealth(health);
            Debug.Log("Player is \"dead\"");
            Destroy(gameObject);
            float elapsedTime = 0;

            while(elapsedTime < 2)
                elapsedTime += Time.deltaTime;

            GameManager.instance.GameStateChange(GameManager.GameState.mainMenu);
        }// end of else if

        else
            hb.SetHealth(health);

    }// end of UpdateHealth

}// end of class 
