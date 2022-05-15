using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestKey : Collectable {
	
	public AudioClip openAudioClip;
	public GameObject itemIcon;
	
	protected override void OnCollect() {
		if (!collected) {
			collected = true;
			itemIcon.SetActive(true);
			GetComponent<BoxCollider2D>().enabled = false;
			GetComponent<SpriteRenderer>().enabled = false;
			AudioSource.PlayClipAtPoint(openAudioClip, transform.position);
		}
	}
}