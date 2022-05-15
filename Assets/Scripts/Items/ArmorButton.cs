using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class ArmorButton : MonoBehaviour, IPointerClickHandler {
    
    private Hotbar playerHotbar = Hotbar.playerHotbarInstance;
	private int slotNum;

    GameObject player;
    GameObject playerArmor;

    StatusEffect statusE;
	
	public bool isShopItem;

    public Sprite steelArmor;
    public Sprite goldArmor;
    public Sprite mageRobesPurple;

    string itemName;
	public int itemCost;
    //public float dmgReduction;
	
	
	public GameObject itemGameObject;

    void Start() {
        player = GameObject.Find("Player");
        playerArmor = player.transform.GetChild(3).gameObject;
        statusE = player.GetComponent<StatusEffect>();
    }
	
	public virtual void OnPointerClick(PointerEventData eventData) {
		if (eventData.button == PointerEventData.InputButton.Left)
			if (!isShopItem)
				OnButtonPressArmor();
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
			Debug.Log("Picked up: " + itemName);
			Destroy(transform.gameObject);
		}
	}

	public void OnButtonPressArmor() {
		if (!isShopItem) {
			slotNum = (int)Char.GetNumericValue(transform.parent.gameObject.name[5]);

			itemName = transform.gameObject.name;

			Debug.Log(itemName);
        
			if(itemName == "SteelArmorButton(Clone)") {
				playerArmor.GetComponent<SpriteRenderer>().sprite = steelArmor;
				player.GetComponent<Player>().setDmgReduction(0.25f);
				statusE.hasHealthTick = false;
				statusE.hasManaTick = false;
			}
			if(itemName == "GoldArmorButton(Clone)") {
				playerArmor.GetComponent<SpriteRenderer>().sprite = goldArmor;
				player.GetComponent<Player>().setDmgReduction(0.50f);
				statusE.hasHealthTick = true;
				statusE.hasManaTick = false;
			}
			if(itemName == "MageRobesButton(Clone)") {
				playerArmor.GetComponent<SpriteRenderer>().sprite = mageRobesPurple;
				player.GetComponent<Player>().setDmgReduction(0.10f);
				statusE.hasHealthTick = false;
				statusE.hasManaTick = true;
			}

			playerHotbar.isUsed[slotNum - 1] = false;
			Destroy(transform.gameObject);
		}
	}
}