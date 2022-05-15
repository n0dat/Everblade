using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
*   This script just changes the filling in the healthbar according to player health
*   There is a thing in the actual unity editor that you need to apply if you don't want to fuck shit up
*   Under the healthBar object you will find the HealthBar script component attached to it. 
*   Under the "slider" you have to attach the healthbar itself to the slider, so you can just drag it to it. 
*   I'll put this in the playerHealth.s file as well, but you also have to attach the healthBar to the playerHealth Script component that is attached to the player.
*   So under player there is a playerHealth script component. Go to this and drag the healthBar object to the hb part of the script that is shown.  
*/
public class healthBar : MonoBehaviour{

    public Slider slider;

    /*
    *   For anyone that comes in here, this file set the slider attribute of the healthBar
    *   what this means is that in the UI for unity, the healthBar can move up or down 
    *   according to the player health. "Slider" is a component that you can add to the 
    *   healthBar. The max of the healthBar is set when the game starts and changes according to ceratin things. 
    *   the numbers that change the healthBar values are found in playerHealth.cs and can be changed by enemyDmg.cs 
    */
    public void setMaxHealth(float health){
        slider.maxValue = health;
        slider.value = health;
    }// end of setMaxHealth

    public void UpdateMaxHealth(float health){
        slider.maxValue = health;
    }

    public void SetHealth(float health){
        slider.value = health;
    }// end of SetHealth
}// end of class healthBar
