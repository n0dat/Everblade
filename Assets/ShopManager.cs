using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour {

	// keep track of where we are in the menus 0 - 2
	public int currentPos;
	// hold the menu srites
	public Sprite[] sprites = new Sprite[3];
	// holds the game objects for the various menus
	public GameObject[] menus = new GameObject[3];
	// holds the shop interactable object
	GameObject sm;
	// holds player object
	GameObject player;
	// bool to tell if player can move
	public bool playerCanMove;
	
	void Start() {
		sm = GameObject.Find("ShopInteractable");
		player = GameObject.Find("Player");
		currentPos = 0;
		exitMenu();
	}
	
	void Update() {
		if (sm.GetComponent<ShopMenu>().isOpen) {
			player.GetComponent<Player>().enabled = false;
			playerCanMove = false;
		}
		else {
			if (!playerCanMove) {
				player.GetComponent<Player>().enabled = true;
				playerCanMove = true;
			}
		}
	}
	
	public void openMenu() {
		menus[0].SetActive(true);
	}
	
	public void changeMenu(string direction) {
		if (currentPos < 1) {
			if (direction == "right") {
				exitMenu();
				menus[1].SetActive(true);
				currentPos = 1;
				return;
			}
		}
		else if (currentPos < 2) {
			if (direction == "left") {
				exitMenu();
				menus[0].SetActive(true);
				currentPos = 0;
				return;
			}
			else if (direction == "right") {
				exitMenu();
				menus[2].SetActive(true);
				currentPos = 2;
				return;
			}
		}
		else {
			if (direction == "left") {
				exitMenu();
				menus[1].SetActive(true);
				currentPos = 1;
				return;
			}
		}
	}
	
	public void exitMenu() {
		foreach (GameObject g in menus)
			g.SetActive(false);
		currentPos = 0;
	}
}
