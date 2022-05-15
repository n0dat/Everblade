using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDmgProjectilePoison : Collidable {
    
    public float speed = 0.1f;
    public int ticks;
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
            collider.GetComponent<StatusEffect>().applyPoison(ticks);   
            Destroy(gameObject);
        }
        else if (collider.tag == "Wall")
            Destroy(gameObject);
            
	}
}// end of class enemyDmg
