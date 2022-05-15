using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {
    // Start is called before the first frame update
	
	public bool isPaused = false;
    [SerializeField] GameObject pauseMenu;
	
	
	public void Pause() {
		Debug.Log("Game Paused");
		isPaused = true;
		pauseMenu.SetActive(true);
		Time.timeScale = 0f;
	}
	
	public void Resume() {
		Debug.Log("Game Unpaused");
		isPaused = false;
		pauseMenu.SetActive(false);
		Time.timeScale = 1f;
	}
	
	public void MainMenu(int SceneID) {
		Time.timeScale = 1f;
		Resume();
		//GameManager.instance.GameStateChange(GameManager.GameState.mainMenu);
		GameManager.LoadGameScene("Main_Menu");
		GameManager.UnloadAllScenes(1);
		
	}
	
    // Update is called once per frame
    void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Debug.Log("Escape key pressed");
			
			if (isPaused) {
				Resume();
			}
			else {
				Pause();
			}
			Debug.Log("Paused: " + isPaused);
		}
    }
}
