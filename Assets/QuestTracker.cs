using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestTracker : MonoBehaviour {
	
	public bool[] activeQuests = new bool[3];
	//public GameObject[] quests = new GameObject[3];
	public bool[] completedQuests = new bool[3];
	public AudioClip openAudioClip;
	public GameObject quest2NPC;
	public GameObject quest2HousePortal;
	
	// 0 - bag of rubies (worth 5)
	// 1 - single ruby (worth 1)
	// 2 - fire sword
	public GameObject[] rewards = new GameObject[4];
	public int count;
	
	GameObject player;

	void Start() {
	
		quest2HousePortal.SetActive(false);
	
		player =  GameObject.Find("Player");

		for (int i = 0; i < activeQuests.Length; i++) {
			activeQuests[i] = false;
			completedQuests[i] = false;
		}
	}
	
	public void ActivateQuest(int index) {
		activeQuests[index] = true;
	}
	
	public void deactivateQuest(int index) {
		activeQuests[index] = false;
	}
	
	public void CompleteQuest(int index) {
		AudioSource.PlayClipAtPoint(openAudioClip, player.transform.position);
		completedQuests[index] = true;			
	}
	
	public void QuestReward(int index, Vector3 pos, float offset) {
		if (index == 0) {
			Object.Instantiate(rewards[0], new Vector3(pos.x, pos.y + offset, pos.z), Quaternion.identity);
			Object.Instantiate(rewards[0], new Vector3(pos.x, pos.y + offset, pos.z), Quaternion.identity);
		}
		else if (index == 1) {
			Object.Instantiate(rewards[2], new Vector3(pos.x, pos.y + offset, pos.z), Quaternion.identity);
		}
		else if (index == 2) {
			
			Object.Instantiate(rewards[0], new Vector3(pos.x, pos.y + offset, pos.z), Quaternion.identity);
			Object.Instantiate(rewards[0], new Vector3(pos.x, pos.y + offset, pos.z), Quaternion.identity);
			Object.Instantiate(rewards[1], new Vector3(pos.x, pos.y + offset, pos.z), Quaternion.identity);
			Object.Instantiate(rewards[1], new Vector3(pos.x, pos.y + offset, pos.z), Quaternion.identity);
			Destroy(quest2NPC);
			quest2HousePortal.SetActive(true);

			/*
			int bags = (int) (count / 5);
			int singles = count % 5;
			if (bags > 0) {
				for (int i = 0; i < bags; i++)
					Object.Instantiate(rewards[0], new Vector3(pos.x, pos.y + offset, pos.z), Quaternion.identity);
			}
			if (singles > 0) {
				for (int i = 0; i < bags; i++)
					Object.Instantiate(rewards[1], new Vector3(pos.x, pos.y + offset, pos.z), Quaternion.identity);
			}
			*/
		}
	}
	/*
	 * Guy asks you to kill some demon babies to get key back into his house in the overworld.
	 * You get the key and give it back, he rewards you by letting you into his house. Where he will give you 15 Rubies.
	 */
}