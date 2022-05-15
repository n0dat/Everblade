using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//This script keeps the logic for dropping items out of slot.
public class Slot : MonoBehaviour {
	public int slotNum;
	public Hotbar playerHotbar;
    
	public void OnDropped() {
		if (transform.childCount > 0) {	
			transform.GetChild(0).gameObject.GetComponent<Spawn>().SpawnDroppedItem(); //Make sure to add Spawn to all items.
			Destroy(transform.GetChild(0).gameObject);
			playerHotbar.isUsed[slotNum - 1] = false;
			Debug.Log("slotnum holding item: " + slotNum);
		}
	}
}
