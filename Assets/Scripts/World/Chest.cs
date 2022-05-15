using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable {

	public Sprite emptyChest;
	public int rubiesAmount;
	public AudioClip openAudioClip;

	public GameObject itemToDrop;
	public float howFar = 0.3f;
	
	void Start() {
		rubiesAmount = 5;
	}
	
	protected override void OnCollect() {
		if (!collected) {
			collected = true;
			player.GetComponent<playerRubies>().addRubies(rubiesAmount);
			Debug.Log("You collected " + rubiesAmount + " rubies.");

			// will switch to empty chest sprite once we collect the rubies.
			GetComponent<SpriteRenderer>().sprite = emptyChest;
			AudioSource.PlayClipAtPoint(openAudioClip, transform.position);

			if (itemToDrop != null){
				Vector3 placeToSpawn = transform.position;
				placeToSpawn.y = placeToSpawn.y + howFar;
				Object.Instantiate(itemToDrop, placeToSpawn, Quaternion.identity);
			}// end of if 
		}
	}
}
