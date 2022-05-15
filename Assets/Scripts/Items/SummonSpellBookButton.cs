using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class SummonSpellBookButton : MonoBehaviour, IPointerClickHandler
{
    private playerHealth ph = playerHealth.playerHealthInstance;
	private Hotbar playerHotbar = Hotbar.playerHotbarInstance;
	private int slotNum;

    GameObject player;
    private playerCombat pc;
	
	public GameObject itemGameObject;	

	public bool isShopItem;
	public int itemCost;
	
    void Start() {
        player = GameObject.Find("Player");
        pc = player.GetComponent<playerCombat>();
    }

	public virtual void OnPointerClick(PointerEventData eventData) {
		if (eventData.button == PointerEventData.InputButton.Left)
			if (!isShopItem)
				OnButtonPress();
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

    public void OnButtonPress() {
		slotNum = (int)Char.GetNumericValue(transform.parent.gameObject.name[5]);
		pc.hasHealSpellEquipt = false;
        pc.hasFireSpellEquipt = false;
        pc.hasPoisonSpellEquipt = false;
        pc.hasSummonSpellEquipt = true;
		playerHotbar.isUsed[slotNum - 1] = false;
		Destroy(transform.gameObject);
	}
}