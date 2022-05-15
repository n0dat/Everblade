using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	
	private GameObject leaveButton;
	
	// 0 - leave button
	// 1 - exit button
	// 2 - play button
	// 3 - settings button
	public GameObject[] buttons = new GameObject[4];
	
	public GameObject title;
	
	public GameObject keybinds;
	
	public void PlayGame() {
		SceneManager.LoadScene("Entrance");
		SceneManager.UnloadScene("Main_Menu");
	}
	
	public void QuitGame() {
		Debug.Log("Game has been Quit!");
		Application.Quit();
	}
	
	public void LoadMain(bool opt) {
		buttons[0].SetActive(!opt);
		buttons[1].SetActive(opt);
		buttons[2].SetActive(opt);
		buttons[3].SetActive(opt);
		title.SetActive(opt);
		keybinds.SetActive(!opt);
	}
	
	public void Settings() {
		LoadMain(false);
	}
	
	public void LeaveMenu() {
		LoadMain(true);
	}
}