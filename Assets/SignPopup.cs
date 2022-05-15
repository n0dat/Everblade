using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignPopup : Collidable {

	public bool isOpen;
	public GameObject popup;
	public int signIndex;
	
	public void Close() {
		popup.SetActive(false);
		Debug.Log("Closed the sign");
		isOpen = false;
		Debug.Log("Player movement enabled");
		player.GetComponent<Player>().enabled = true;
	}
	
	public void Open() {
		popup.SetActive(true);
		Debug.Log("Opened the sign");
		isOpen = true;
		Debug.Log("Player movement disabled");
		player.GetComponent<Player>().enabled = false;
	}
	
	protected override void OnCollide(Collider2D collider) {
		if (collider.name == "Player") {
			if (Input.GetKeyDown(KeyCode.E) && !isOpen) {
				Open();
			}
			else if (Input.GetKeyDown(KeyCode.E) && isOpen) {
				Close();
			}
		}
	}
}
