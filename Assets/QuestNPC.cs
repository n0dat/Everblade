using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestNPC : Collidable {
	
	public bool isOpen;
	public GameObject qManager;
	public int questIndex;
	public Text messageText;
	public GameObject questMenu;
	public bool claimed;
	public float offset;

	// 0 - Close Button
	// 1 - Accept Button
	// 2 - Deny Button
	// 3 - Claim Button
	// 4 - Back Button
	// 5 - Next Button
	public GameObject[] buttons = new GameObject[6];
	
	public void CleanMenu() {
		for (int i = 0; i < buttons.Length; i++)
			buttons[i].SetActive(false);
		buttons[0].SetActive(true);
	}
	
	public void MenuSwitch(string direction) {
		if (direction == "next") {
			buttons[0].SetActive(false);
			buttons[1].SetActive(true);
			buttons[2].SetActive(true);
			buttons[3].SetActive(false);
			buttons[4].SetActive(true);
			buttons[5].SetActive(false);
			messageText.text = qManager.GetComponent<QuestMessages>().proposalMessages[questIndex];
		}
		else if (direction == "back") {
			buttons[0].SetActive(true);
			buttons[1].SetActive(false);
			buttons[2].SetActive(false);
			buttons[3].SetActive(false);
			buttons[4].SetActive(false);
			buttons[5].SetActive(true);
			messageText.text = qManager.GetComponent<QuestMessages>().npcDialogue[questIndex];
		}
		else {
			Debug.Log("Invalid direction selected");
		}
	}

	public void OnLoad() {
		messageText.text = qManager.GetComponent<QuestMessages>().npcDialogue[questIndex];
		CleanMenu();
		buttons[5].SetActive(true);
	}
	
	public void Close() {
		Debug.Log("Closed the NPC dialogue");
		questMenu.SetActive(false);
		isOpen = false;
		Debug.Log("Player movement enabled");
		player.GetComponent<Player>().enabled = true;
		for (int i = 0; i < buttons.Length; i++)
			buttons[i].SetActive(false);
		OnLoad();
	}
	
	public void Acccept() {
		Debug.Log("Accepted the quest");
		qManager.GetComponent<QuestTracker>().ActivateQuest(questIndex);
		messageText.text = qManager.GetComponent<QuestMessages>().thankMessages[questIndex];
		CleanMenu();
	}
	
	public void Deny() {
		Debug.Log("Denied the quest");
		messageText.text = qManager.GetComponent<QuestMessages>().denyMessages[questIndex];
		CleanMenu();
	}
	
	public void Claim() {
		Debug.Log("Claimed the reward");
		qManager.GetComponent<QuestTracker>().CompleteQuest(questIndex);
		claimed = true;
		Close();
		CleanMenu();
		SpawnReward();
	}
	
	public void Completed() {
		CleanMenu();
		Debug.Log("Completed the quest");
		buttons[3].SetActive(true);
		messageText.text = qManager.GetComponent<QuestMessages>().completeMessage[questIndex];
		Debug.Log(qManager.GetComponent<QuestMessages>().completeMessage[questIndex]);
	}
	
	public void Open() {
		Debug.Log("Opened the NPC dialogue");
		questMenu.SetActive(true);
		isOpen = true;
		Debug.Log("Player movement disabled");
		player.GetComponent<Player>().enabled = false;
	}
	
	public void SpawnReward() {
		qManager.GetComponent<QuestTracker>().QuestReward(questIndex, transform.position, offset);
	}
	
	protected override void OnCollide(Collider2D collider) {
		if (collider.name == "Player") {
			if (Input.GetKeyDown(KeyCode.E) && !isOpen) {
				if (qManager.GetComponent<QuestTracker>().activeQuests[questIndex]) {
					if (qManager.GetComponent<QuestTracker>().completedQuests[questIndex]) {
						if (!claimed)
							Completed();
						else {
							messageText.text = qManager.GetComponent<QuestMessages>().comebackMessage;
							CleanMenu();
						}
					}
					else {
						messageText.text = qManager.GetComponent<QuestMessages>().incompleteMessage;
						CleanMenu();
					}
				}
				else
					OnLoad();

				Open();
			}
			else if (Input.GetKeyDown(KeyCode.E) && isOpen) {
				Close();

			}
		}
	}
}
