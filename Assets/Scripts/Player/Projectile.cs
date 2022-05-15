using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Collidable
{
    public float speed = 0.01f;
    private Animator anim;

    Vector3 shootDirection;

    void FixedUpdate(){
        transform.Translate(shootDirection*speed);
    }//end FixedUpdate

    // Start is called before the first frame update
    void Start(){

        shootDirection = Input.mousePosition;
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = (shootDirection - transform.position).normalized;
        
    }

    protected override void OnCollide(Collider2D myCollider){
        // alternative if you do not want to create an entire new game object
        // just to check the collider of anything it hits  -James
        if (myCollider.gameObject.transform.parent != null) {
            if (myCollider.gameObject.tag == "Enemy" || myCollider.gameObject.tag == "EnemyBoss") {
                myCollider.gameObject.transform.parent.gameObject.GetComponent<enemyBehavior>().UpdateHealth(-10);
                //myCollider.gameObject.transform.parent.gameObject.GetComponent<EnemyStatusEffect>().applyPoison(5);
                Destroy(gameObject);
            }
        }
    }//end OnCollide
}
