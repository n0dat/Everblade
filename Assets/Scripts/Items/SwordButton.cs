using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class SwordButton : MonoBehaviour, IPointerClickHandler {	
    
    private Hotbar playerHotbar = Hotbar.playerHotbarInstance;
	private int slotNum;

    GameObject player;
    GameObject playerSword;
    playerCombat playerDamage;

    //SpriteRenderer rend;
    public Sprite blueSword;
    public Sprite redSword;
    public Sprite goldSword;
    public Sprite greenSword;
    public Sprite blackSword;

    string itemName;
	public int itemCost;
	
	public GameObject itemGameObject;
	
	public bool isShopItem;

    void Start() {
        player = GameObject.Find("Player");
        playerSword = player.transform.GetChild(2).gameObject;
        playerDamage = player.GetComponent<playerCombat>();
    }
	
	public virtual void OnPointerClick(PointerEventData eventData) {
		if (eventData.button == PointerEventData.InputButton.Left)
			if (!isShopItem)
				OnButtonPressSword();
			else {
				if (player.GetComponent<playerRubies>().getRubies() >= itemCost) {
					player.GetComponent<playerRubies>().removeRubies(itemCost);
					Debug.Log("Bought the item");
					Vector3 placeToSpawn = player.transform.position;
					placeToSpawn.y = placeToSpawn.y + 0.2f;
					Instantiate(itemGameObject, placeToSpawn, Quaternion.identity);
				}
				else {
					Debug.Log("Insufficient rubies");
				}
			}
		else if (eventData.button == PointerEventData.InputButton.Right && !isShopItem) {
			slotNum = (int)Char.GetNumericValue(transform.parent.gameObject.name[5]);
			playerHotbar.isUsed[slotNum - 1] = false;
			itemGameObject.GetComponent<ItemPickup>().PickUp();
			Destroy(transform.gameObject);
		}
		
	}
	
	public void OnButtonPressSword() {   
		slotNum = (int)Char.GetNumericValue(transform.parent.gameObject.name[5]);

        itemName = transform.gameObject.name;

        Debug.Log(itemName);
        
        if(itemName == "SwordBlueButton(Clone)") {
            playerSword.GetComponent<SpriteRenderer>().sprite = blueSword;
            playerDamage.attackDamage = 10f;
            playerDamage.hasPoisonWeapon = false;
        }
        if(itemName == "SwordGoldButton(Clone)") {
            playerSword.GetComponent<SpriteRenderer>().sprite = goldSword;
            playerDamage.attackDamage = 15f;
            playerDamage.hasPoisonWeapon = false;
        }
        if(itemName == "SwordRedButton(Clone)") {
            playerSword.GetComponent<SpriteRenderer>().sprite = redSword;
            playerDamage.attackDamage = 20f;
            playerDamage.hasPoisonWeapon = false;
        }
        if(itemName == "SwordBlackButton(Clone)") {
            playerSword.GetComponent<SpriteRenderer>().sprite = blackSword;
            playerDamage.attackDamage = 25f;
            playerDamage.hasPoisonWeapon = false;
        }
        if(itemName == "SwordGreenButton(Clone)") {
            playerSword.GetComponent<SpriteRenderer>().sprite = greenSword;
            playerDamage.attackDamage = 7f;
            playerDamage.hasPoisonWeapon = true;
        }

		playerHotbar.isUsed[slotNum - 1] = false;
		Destroy(transform.gameObject);
	}
}
