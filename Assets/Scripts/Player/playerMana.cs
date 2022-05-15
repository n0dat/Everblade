using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMana : MonoBehaviour {
    #region Singleton

    // doing this shoudl allow you to interact with one inventory at all times?? I have no idea, brackeys 
    public static playerMana playerManaInstance;

    void Awake(){
        if (playerManaInstance != null){
            Debug.LogWarning("more than one instance of player mana found!");
            return;
        }
        playerManaInstance = this;
    }
    #endregion

    public float mana = 1f;
    
    //a healthBar obj is created so that the healthBar in game 
    //will move according to the actual players health
    public ManaBar mb;
    
    // Audio clip for taking damage
    public AudioClip damageAudioClip;

    // the serializeField should allow for the heealth to be messed 
    // with in the unity editor but still be private
    public float maxMana = 100f;

    // setMaxHealth and follwoign SetHealth are function found in healthBar.cs
    // what they do will be explained in said file 
    private void Start() {

        mana = maxMana;
        mb.setMaxMana(maxMana);

    }// end of Start 

    /*  
    *   this should allow you to add health, so say you pick up a pot or fountain 
    *   you don't want the player to have more health than they should or decrease 
    *   health if you should get some kind of dmg
    */ 

    public float GetMana() {
        return mana;
    }

    public float GetmaxMana(){
        return maxMana;
    }

    public void UpdateMaxMana(float mod){
        mb.UpdateMaxMana(maxMana + mod);
        //ph.UpdateHealth(1);
        maxMana += mod;
    }

    public void UpdateMana(float mod) {

        mana += mod;
        
        if (mod < 0)
            AudioSource.PlayClipAtPoint(damageAudioClip, transform.position);

        // doesn't allow for the player to have more health than allowed
        if(mana > maxMana) {
            mana = maxMana;
            mb.SetMana(mana);
        }// end of if 

        /*
        *   setting the health to zero allows the player to die without the health bar gong further
        *   back than it needs to. Meaning if the health goees into the negative because of a sufficiently 
        *   storng attack from an enemy, it won't acutally become negative and will insteead just default to zero 
        */

        else if(mana <= 0) {
            mana = 0f;
            mb.SetMana(mana);
            Debug.Log("Player is out of mana");
        }// end of else if

        else 
            mb.SetMana(mana);

    } // end of UpdateHealth
}
