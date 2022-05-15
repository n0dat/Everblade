using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest3 : MonoBehaviour {
	public GameObject questManager;
	public GameObject largeOrc;
	public GameObject questNPC;
	
	void Start() {
		questManager = GameObject.Find("QuestManager");
		questNPC = GameObject.Find("Quest3NPC");
	}
	
	void Update() {
		if (largeOrc == null) {
			questManager.GetComponent<QuestTracker>().CompleteQuest(1);
			Destroy(gameObject);
		}
	}
}
