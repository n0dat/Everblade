using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShooting : MonoBehaviour {
   
    public GameObject projectile;

    // references the ai of the specific enemy this script is attached to
    public EnemyAI ai;

    public float fireRate;
    private float fireRateCopy;
    public int canFire;
    //public float nextFire = 0.1f;
	
	public float distanceToPlayer;

    private void Start() {
		//distanceToPlayer = 3;
        //fireRate = 0.0f;
        //nextFire = 1f;
        fireRateCopy = fireRate;
    }

    void Update() {
        if (Vector3.Distance(GameObject.Find("Player").transform.position, transform.position) < distanceToPlayer)
            CheckIfTimeToFire();
    }

    void CheckIfTimeToFire() {
        fireRateCopy -= Time.deltaTime;

        if (fireRateCopy <= 0 && canFire > 0) {
            Instantiate(projectile, transform.position, Quaternion.identity);
            fireRateCopy = fireRate;
            canFire--;
        }
        if(canFire == 0){
            ai.setStopDistance(0.13f);
        }
    }
}
