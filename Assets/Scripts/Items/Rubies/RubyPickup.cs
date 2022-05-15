using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyPickup : Collectable {
	
	public AudioClip openAudioClip;
	
	protected override void OnCollect() {
		if (!collected) {
			collected = true;
			player.GetComponent<playerRubies>().addRubies(1);
			Destroy(gameObject);
			AudioSource.PlayClipAtPoint(openAudioClip, transform.position);
		}
	}
}