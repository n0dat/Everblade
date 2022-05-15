using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour{
    public Slider slider;

    /*
    *   For anyone that comes in here, this file set the slider attribute of the healthBar
    *   what this means is that in the UI for unity, the healthBar can move up or down 
    *   according to the player health. "Slider" is a component that you can add to the 
    *   healthBar. The max of the healthBar is set when the game starts and changes according to ceratin things. 
    *   the numbers that change the healthBar values are found in playerHealth.cs and can be changed by enemyDmg.cs 
    */
    public void setMaxMana(float mana){
        slider.maxValue = mana;
        slider.value = mana;
    }// end of setMaxMana

    public void UpdateMaxMana(float mana){
        slider.maxValue = mana;
    }

    public void SetMana(float mana){
        slider.value = mana;
    }// end of SetHealth
}
