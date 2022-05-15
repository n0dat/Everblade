using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onEnemyCollision : Collidable{

	public float attackDamage;
	public float newAttackDmg;
	public bool hasPoisonAttack = false;
	public int ticks;
	float playerDmgReduction;
	ArmorButton playerArmor;
    
	override protected void OnCollide(Collider2D collider)
	{
		playerDmgReduction = player.GetComponent<Player>().getDmgReduction();
		newAttackDmg = attackDamage - (attackDamage * playerDmgReduction);
		if (collider.name == "Player"){
			if (timer >= 1) //Make sure we have a max hit speed. We want 1 hit per second
			{
				if(hasPoisonAttack)
					collider.GetComponent<StatusEffect>().applyPoison(ticks);  
				playerHealth.playerHealthInstance.UpdateHealth(-newAttackDmg);
				timer = 0;
			}
		}
	}
    
}
