using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour {

    public GameObject bloodSplash;

    private float health;

    public GameObject itemToDrop;
	public float howFar = 0.3f;

    public enemyHealthB hb;
    [SerializeField] private float maxHealth = 100f;

    private void Start() {
        health = maxHealth;
        hb.setEnemyHealthMax(health);
    }// end of Start 

    public void UpdateHealth(float mod) {

        //update the health
        health += mod;

        if(health > maxHealth) {
            health = maxHealth;
            hb.setEnemeyHealth(health);
        }// end of if 

        else if(health <= 0) {
            health = 0f;
            hb.setEnemeyHealth(health);
            Debug.Log("Enemy is \"dead\"");
            Instantiate(bloodSplash, transform.position, Quaternion.identity);
			Destroy(gameObject);
            //gameObject.SetActive(false);

            if (itemToDrop != null) {
				Vector3 placeToSpawn = transform.position;
				placeToSpawn.y = placeToSpawn.y + howFar;
				Object.Instantiate(itemToDrop, placeToSpawn, Quaternion.identity);
			}// end of if 
        }// end of else if

        else {
            //If you aren't dead or have too much health, also update the healthbar to match health.
            hb.setEnemeyHealth(health);
        }// end of else 

    }// end of UpdateHealth
}
