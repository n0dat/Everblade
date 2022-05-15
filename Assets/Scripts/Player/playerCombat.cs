using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCombat : MonoBehaviour {

	public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public float attackDamage = 10f;
    private float canAttack;
	
	public AudioClip swordUse;
	public AudioClip swordHit;
	
    public GameObject projectilePrefab;
    public GameObject projectilePrefabPoison;
    public GameObject summonPrefab;
    public GameObject summonEffect;
	
	private playerMana pm;
    private playerHealth ph;

    public bool hasPoisonWeapon;
    public bool hasHealSpellEquipt;
    public bool hasFireSpellEquipt;
    public bool hasPoisonSpellEquipt;
    public bool hasSummonSpellEquipt;
	
	void Start() {
		pm = GameObject.Find("Player").GetComponent<playerMana>();
        ph = GameObject.Find("Player").GetComponent<playerHealth>();
	}

    // Update is called once per frame
    void Update() {

        if(Input.GetKeyDown(KeyCode.Space))
            Attack();

        // calls shoot should the player input f
        if(Input.GetKeyDown("f")) {
            //if(playerMana.playerManaInstance.GetMana() == 0)
			if (pm.GetMana() == 0)
                Debug.Log("you ran out of mana");
            else if(hasFireSpellEquipt && pm.GetMana() > 0)
                Shoot();
            else if(hasHealSpellEquipt && pm.GetMana() > 0)
                HealSpell();
            else if(hasPoisonSpellEquipt && pm.GetMana() > 0)
                ShootPoison();
            else if(hasSummonSpellEquipt && pm.GetMana() > 0 && pm.GetMana() >= 55)
                Summon();
            

        } // end of if 
    } // end of update

    void Shoot() {
        // instantiates the projectile prefab
        // right at the attackPoint which is in front of the player character
        Instantiate(projectilePrefab, attackPoint.position, attackPoint.rotation);
        //playerMana.playerManaInstance.UpdateMana(-10);
		pm.UpdateMana(-10);
    } // end of Shoot

    void ShootPoison(){
        Instantiate(projectilePrefabPoison, attackPoint.position, attackPoint.rotation);
		pm.UpdateMana(-10);
    }

    void Summon(){
        Instantiate(summonEffect, transform.position, Quaternion.identity);
        Instantiate(summonPrefab, attackPoint.position, attackPoint.rotation);
		pm.UpdateMana(-55);
    }

    void HealSpell(){
        pm.UpdateMana(-20);
        ph.UpdateHealth(20);
    }

    void Attack() {

    	//Handle animation.
    	animator.SetTrigger("Attack Trigger"); //Call the animation trigger.
		
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
		
		if (hitEnemies.Length == 0 || hitEnemies == null)
			AudioSource.PlayClipAtPoint(swordUse, transform.position);
		
        foreach(Collider2D Enemy in hitEnemies) {
            
            if(Enemy.tag == "Enemy"){
                if(hasPoisonWeapon) {
                    Enemy.gameObject.transform.parent.gameObject.GetComponent<EnemyStatusEffect>().applyPoison(4);
                    Debug.Log("We hit " + Enemy.name);
                    Enemy.gameObject.transform.parent.gameObject.GetComponent<enemyBehavior>().UpdateHealth(-attackDamage);
                    Debug.Log("You hit for" + attackDamage);
                    Debug.Log("Poison Weapon: " + hasPoisonWeapon);
                    AudioSource.PlayClipAtPoint(swordHit, transform.position);
                }
                else {
                    Debug.Log("We hit " + Enemy.name);
                    Enemy.gameObject.transform.parent.gameObject.GetComponent<enemyBehavior>().UpdateHealth(-attackDamage);
                    Debug.Log("Yu hit for" + attackDamage);
                    Debug.Log("Poison Weapon: " + hasPoisonWeapon);
                    AudioSource.PlayClipAtPoint(swordHit, transform.position);
                }
            }

        } // end of foreach
    } // end of attack

    void OnDrawGizmosSelected() {

        if(attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    } // end of OnDrawGSelected
} // end of playerCombat