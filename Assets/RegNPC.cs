using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegNPC : Collidable {
	
	public bool isOpen;
	public GameObject dialogueMenu;
	
	public void Close() {
		Debug.Log("Closed NPC dialogue");
		dialogueMenu.SetActive(false);
		isOpen = false;
		player.GetComponent<Player>().enabled = true;
		Debug.Log("Enabled player movement");
	}
	
	public void Open() {
		Debug.Log("Opened NPC dialogue");
		dialogueMenu.SetActive(true);
		isOpen = true;
		player.GetComponent<Player>().enabled = false;
		Debug.Log("Disabled player movement");
	}
	
	protected override void OnCollide(Collider2D collider) {
		if (collider.name == "Player") {
			if (Input.GetKeyDown(KeyCode.E) && !isOpen) {
				Debug.Log("Menu opened");
				Open();
			}
			else if (Input.GetKeyDown(KeyCode.E) && isOpen) {
				Debug.Log("Menu closed");
				Close();
			}
		}
	}
}