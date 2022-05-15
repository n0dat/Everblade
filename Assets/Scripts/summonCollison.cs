using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class summonCollison : Collidable
{
    public GameObject summon;
    public float attackDamage;
    override protected void OnCollide(Collider2D collider)
	{
		if (collider.tag == "Enemy"){
			if (timer >= 1) //Make sure we have a max hit speed. We want 1 hit per second
			{
				summon.GetComponent<enemyBehavior>().UpdateHealth(-10);
                collider.gameObject.transform.parent.gameObject.GetComponent<enemyBehavior>().UpdateHealth(-attackDamage);
				timer = 0;
			}
		}
	}
}
