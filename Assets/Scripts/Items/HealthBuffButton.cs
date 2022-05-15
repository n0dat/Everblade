using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class HealthBuffButton : MonoBehaviour, IPointerClickHandler {

	private playerHealth ph = playerHealth.playerHealthInstance;
	private Hotbar playerHotbar = Hotbar.playerHotbarInstance;
	private int slotNum;
	
	public GameObject itemGameObject;
	GameObject player;
	
	public bool isShopItem;
	public int itemCost;
	
	void Start() {
		player = GameObject.Find("Player");
	}
	
	public virtual void OnPointerClick(PointerEventData eventData) {
		if (eventData.button == PointerEventData.InputButton.Left)
			if (!isShopItem)
				OnButtonPressHealthBuff();
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
	
	public void OnButtonPressHealthBuff() {
		slotNum = (int)Char.GetNumericValue(transform.parent.gameObject.name[5]);
		ph.UpdateMaxHealth(12.5f);
		playerHotbar.isUsed[slotNum - 1] = false;
		Destroy(transform.gameObject);
	}
}