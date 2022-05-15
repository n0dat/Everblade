using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]

public class Item : ScriptableObject {

    public string itemName = "New Item";
    public Sprite icon = null;
    public Sprite armor;
    public bool isDefaultItem = false;

    GameObject player;
    GameObject playerSword;
    GameObject playerArmor;
    SpriteRenderer playerArmorSprite;
    SpriteRenderer playerSwordSprite;
    playerCombat playerDamage;
    StatusEffect statusEffect;
	
	public GameObject itemGameObject;

    void ChangeSprite(Sprite newSprite){
        playerSwordSprite.sprite = newSprite;
    }

    void ChangeSpriteArmor(Sprite newSprite){
        playerArmorSprite.sprite = newSprite;
    }

    public virtual void Use() {
        player = GameObject.Find("Player");

        playerSword = player.transform.GetChild(2).gameObject;
        playerSwordSprite = playerSword.GetComponent<SpriteRenderer>();

        playerArmor = player.transform.GetChild(3).gameObject;
        playerArmorSprite = playerArmor.GetComponent<SpriteRenderer>();

        playerDamage = player.GetComponent<playerCombat>();
        statusEffect = player.GetComponent<StatusEffect>();

        if(name == "HealthPotionLarge") {
            playerHealth.playerHealthInstance.UpdateHealth(15);
        }
        if(name == "HealthBuff") {
            playerHealth.playerHealthInstance.UpdateMaxHealth(25);        
        }
        if(name == "ManaPotion") {
            playerMana.playerManaInstance.UpdateMana(15);
        }
        if(name == "ManaBuff") {
            playerMana.playerManaInstance.UpdateMaxMana(25);        
        }
        if(name == "CurePoisonPot"){
            statusEffect.counterPoison = true;
        }
        if(name == "HealingOverTime"){
            statusEffect.applyHealingOverTimePot(5);
        }
        if(name == "ManaOverTime"){
            statusEffect.applyManaOverTimePot(5);
        }

        // end of potions and buffs

        if(name == "SwordBlue") {
            ChangeSprite(icon);
            playerDamage.attackDamage = 10f;
            playerDamage.hasPoisonWeapon = false;
        }
        if(name == "SwordGold") {
            ChangeSprite(icon);
            playerDamage.attackDamage = 15f;
            playerDamage.hasPoisonWeapon = false;
        }
        if(name == "SwordRed") {
            ChangeSprite(icon);
            playerDamage.attackDamage = 20f;
            playerDamage.hasPoisonWeapon = false;
        }
        if(name == "SwordBlack") {
            ChangeSprite(icon);
            playerDamage.attackDamage = 25f;
            playerDamage.hasPoisonWeapon = false;
        }
        if(name == "SwordGreen") {
            ChangeSprite(icon);
            playerDamage.attackDamage = 7f;
            playerDamage.hasPoisonWeapon = true;
        }

        // end of sword items

        if(name == "SteelArmor") {
            ChangeSpriteArmor(armor);
            player.GetComponent<Player>().setDmgReduction(0.25f);
            statusEffect.hasHealthTick = false;
            statusEffect.hasManaTick = false;
        }
        if(name == "GoldArmor") {
            ChangeSpriteArmor(armor);
            player.GetComponent<Player>().setDmgReduction(0.50f);
            statusEffect.hasHealthTick = true;
            statusEffect.hasManaTick = false;
        }
        if(name == "MagesRobes") {
            ChangeSpriteArmor(armor);
            player.GetComponent<Player>().setDmgReduction(0.10f);
            statusEffect.hasHealthTick = false;
            statusEffect.hasManaTick = true;
        }

        // end of armor 

        if(name == "SpellBookHealing"){
            playerDamage.hasHealSpellEquipt = true;
            playerDamage.hasFireSpellEquipt = false;
            playerDamage.hasPoisonSpellEquipt = false;
            playerDamage.hasSummonSpellEquipt = false;
        }
        if(name == "SpellBookFIreBall"){
            playerDamage.hasHealSpellEquipt = false;
            playerDamage.hasFireSpellEquipt = true;
            playerDamage.hasPoisonSpellEquipt = false;
            playerDamage.hasSummonSpellEquipt = false;
        }
        if(name == "SpellBookPoisonBall"){
            playerDamage.hasHealSpellEquipt = false;
            playerDamage.hasFireSpellEquipt = false;
            playerDamage.hasPoisonSpellEquipt = true;
            playerDamage.hasSummonSpellEquipt = false;
        }
        if(name == "SpellBookSummon"){
            playerDamage.hasHealSpellEquipt = false;
            playerDamage.hasFireSpellEquipt = false;
            playerDamage.hasPoisonSpellEquipt = false;
            playerDamage.hasSummonSpellEquipt = true;
        }

        Debug.Log("Using " + name);
    }
}
