using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : Collectable {
	
	public AudioClip openAudioClip;
	
	protected override void OnCollect() {
		if (!collected) {
			collected = true;
			player.GetComponent<playerKeys>().addKeys(1);
			Destroy(gameObject);
			AudioSource.PlayClipAtPoint(openAudioClip, transform.position);
		}
	}
}