using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : Collidable {
	
	public bool isOpen;
	public GameObject manager;
	
    void Start() {
        manager = GameObject.Find("ShopManager");
    }
	
	public void close() {
		isOpen = false;
	}

	protected override void OnCollide(Collider2D collider) {
		Debug.Log("Shop colliding with: " + collider.name);
		if (collider.name == "Player") {
			if (Input.GetKeyDown(KeyCode.E) && !isOpen) {
				manager.GetComponent<ShopManager>().openMenu();
				Debug.Log("Opened the shop");
				isOpen = true;
			}
		}
	}
}
