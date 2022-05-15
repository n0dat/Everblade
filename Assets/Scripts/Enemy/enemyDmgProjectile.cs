using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDmgProjectile : Collidable {
    
    public float speed = 0.1f;
    Transform target;
    Vector3 shootDirection;

    // Start is called before the first frame update
    void Start() {

        target = GameObject.Find("Player").transform;
        shootDirection = target.position - transform.position;
        //shootDirection = (shootDirection - transform.position).normalized;
        //transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void FixedUpdate() {
        transform.Translate(shootDirection * speed);
    }//end FixedUpdate

    override protected void OnCollide(Collider2D collider) {
        Debug.Log("we hit this: " + collider.name);

		if (collider.name == "Player"){
            playerHealth.playerHealthInstance.UpdateHealth(-10);    
            Destroy(gameObject);
        }
        else if (collider.tag == "Wall")
            Destroy(gameObject);
            
	}

     /*void OnTriggerEnter2D(Collider2D hitInfo){
        Debug.Log("This fucker got shot: " + hitInfo.name);
        if(hitInfo != null && hitInfo.name != "Collision"){
            hitInfo.gameObject.transform.parent.gameObject.GetComponent<enemyBehavior>().UpdateHealth(-10);
        }// end of if 
        if(hitInfo.name == "Collision"){
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }// end of OnTriggerEnter2d */
}// end of class enemyDmg
