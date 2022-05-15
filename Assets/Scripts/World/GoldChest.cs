using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldChest : Collectable {

	public Sprite emptyChest;
	//public int rubiesAmount;
	public AudioClip openAudioClip;

	public GameObject itemToDrop;
	public float howFar = 0.3f;
	public float messageLength;
	
	public bool isOpen, canBeOpened, hasCollided;
	
	public GameObject chestMessage;
	
	void Start() {
		//rubiesAmount = 5;
		isOpen = false;
		canBeOpened = false;
		messageLength = 2.0f;
	}
	
	private IEnumerator DisplayMessage(float time) {
		yield return new WaitForSeconds(time);
		chestMessage.SetActive(false);
	}
	
	protected override void OnCollect() {
		if (Input.GetKeyDown(KeyCode.E)) {
			if (!collected) {
				if (!isOpen && player.GetComponent<playerKeys>().getKeys() > 0) {
					Debug.Log("Player has opened a chest with key");
					collected = true;
					player.GetComponent<playerKeys>().removeKeys(1);
					AudioSource.PlayClipAtPoint(openAudioClip, transform.position);
					Debug.Log("Chest opened");
					GetComponent<SpriteRenderer>().sprite = emptyChest;
					if (itemToDrop != null) {
						Vector3 spawnPoint = transform.position;
						spawnPoint.y += howFar;
						Object.Instantiate(itemToDrop, spawnPoint, Quaternion.identity);
					}
				}
				else if (!isOpen && player.GetComponent<playerKeys>().getKeys() < 1) {
					Debug.Log("Player needs a key!");
					chestMessage.GetComponent<TextMeshPro>().text = "You need a key";
					chestMessage.SetActive(true);
					StartCoroutine(DisplayMessage(messageLength));
				}
			}
		}
		/*
		if (!collected) {
			collected = true;
			player.GetComponent<playerRubies>().addRubies(rubiesAmount);
			Debug.Log("You collected " + rubiesAmount + " rubies.");

			// will switch to empty chest sprite once we collect the rubies.
			GetComponent<SpriteRenderer>().sprite = emptyChest;
			AudioSource.PlayClipAtPoint(openAudioClip, transform.position);

			if (itemToDrop != null) {
				Vector3 placeToSpawn = transform.position;
				placeToSpawn.y = placeToSpawn.y + howFar;
				Object.Instantiate(itemToDrop, placeToSpawn, Quaternion.identity);
			}// end of if 
		}
		*/
	}
}