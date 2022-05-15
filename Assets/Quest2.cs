using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest2 : MonoBehaviour {
	
	public GameObject questManager;
	public GameObject[] enemies = new GameObject[10];
	public bool[] enemiesCheck = new bool[10];
	public int enemiesRemaining = 10;
	public GameObject questKey;
	Vector3 lastPos;
	public bool hasSpawned;
	public GameObject questNPC;
	
	void Start() {
		lastPos = enemies[9].transform.position;
		questManager = GameObject.Find("QuestManager");
		for (int i = 0; i < enemiesCheck.Length; i++) {
			enemiesCheck[i] = true;
		}
	}
	
	void Update() {
		if (enemiesRemaining == 0) {
			questManager.GetComponent<QuestTracker>().CompleteQuest(2);
			Destroy(gameObject);
		}
	
		if (enemies[1] == null && !hasSpawned) {
			Object.Instantiate(questKey, new Vector3(lastPos.x, lastPos.y + 0.3f, 0), Quaternion.identity);
			hasSpawned = true;
		}
		
		for (int i = 0; i < enemies.Length; i++) {
			if (enemies[i] == null && enemiesCheck[i]) {
				enemiesRemaining--;
				enemiesCheck[i] = false;
			}
		}
	}
}
