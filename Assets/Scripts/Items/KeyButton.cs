using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class KeyButton: MonoBehaviour, IPointerClickHandler {

	GameObject player;
	
	public int itemCost;
	
    void Start() {
        player = GameObject.Find("Player");
    }

	public virtual void OnPointerClick(PointerEventData eventData) {
		if (eventData.button == PointerEventData.InputButton.Left)
			if (player.GetComponent<playerRubies>().getRubies() >= itemCost) {
				Debug.Log("Bought the item");
				player.GetComponent<playerRubies>().removeRubies(itemCost);
				player.GetComponent<playerKeys>().addKeys(1);
			}
			else
				Debug.Log("Insufficient rubies");
	}
}
