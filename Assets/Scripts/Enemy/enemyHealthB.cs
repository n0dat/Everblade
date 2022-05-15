using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealthB : MonoBehaviour
{
    public Slider Slider;
    public Vector3 offset;
    public float maxHealth;
    private float health1;

    /*public void setEnemyHealthBar(float health, float maxHealth){
        
        Slider.value = health;
        Slider.maxValue = maxHealth;

        Slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, High, Slider.normalizedValue);
        Slider.maxValue = health;
        Slider.value = health;
    }*/

    private void Start() {
        Slider.gameObject.SetActive(false);
    }

    public void setEnemyHealthMax(float health) {
        maxHealth = health;
        Slider.maxValue = health;
        Slider.value = health;
    }

    public void setEnemeyHealth(float health) {
        health1 = health;
        if(health1 < maxHealth) {
            Slider.gameObject.SetActive(true);
        }
        Slider.value = health;
    }// end of SetHealth

    // Update is called once per frame
    
    void Update () {
     Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
}
