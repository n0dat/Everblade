using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//NOTES: a delegate is a pointer to a single, or a group of methods with the same function signature. When you call that delegate all methods subscribed to it run.
//Events are special delegates in which you cannot set a delegate to only one method/ and you cannot call that delegate outside of the class it was defined in.
public class GameManager : MonoBehaviour {
	public static GameManager instance;
	public List<Sprite> playerSprites;
	public List<Sprite> weaponSprites;
	public List<int> weaponPrices;
	public List<int> xpTable;
	private delegate void OnGameStateChange(GameState gs);
	private event OnGameStateChange OnGameStateChangeEvent;

	//References to different scripts.
	public Player player;
	//public weapon weapon

	//Logic
	public playerRubies rubies;
	public int experience;

	public enum GameState {mainMenu, town, quit, alive, main};
	public enum SceneToLoad {DungeonTest};
	
	public void GameStateChange(GameState gs) {
		switch (gs) {
			case GameState.mainMenu: 
				SceneManager.LoadScene("Main_Menu");
				Debug.Log("Main_Menu");
				break;
			case GameState.alive:
				break;
			case GameState.town:
				SceneManager.LoadScene("Town");
				Debug.Log("Town");
				break;
			case GameState.quit:
				Application.Quit();
				break;
			case GameState.main:
				SceneManager.LoadScene("Main");
				Debug.Log("Main");
				break;
			default:
				Debug.Log("enum passed to OnGameStateChange is not valid.");
				break;
			//OnGameStateChangeEvent.Invoke(gs);
		}
	}

	public static void LoadGameScene(string sceneName){
		if (SceneManager.GetSceneByName(sceneName).isLoaded)
			Debug.Log("Already loaded scrub noob sheeeeeeeesh");
		else if (sceneName == "Main_Menu")
			SceneManager.LoadScene("Main_Menu");
		else
			SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
	
	} //end LoadGameScene()	

	// this is really gross and only works 
	public static void UnloadAllScenes(int flag) {
		for (int i = 0; i < SceneManager.sceneCount; i++) {
			Scene scene = SceneManager.GetSceneAt(i);
			print(scene.name);
			SceneManager.UnloadSceneAsync(scene);
		}
		
		if (flag == 1) {
			GameObject[] objectArr = {GameObject.Find("Player"), GameObject.Find("Canvas"), GameObject.Find("Main Camera"), GameObject.Find("PlayerHotbar")};
			foreach(GameObject i in objectArr) {
				print("object name: " + i.name);
				i.SetActive(false);
			}
		}
	}

	//Saving the game

	/* 
	int playerSkin
	int rubies
	int expierence
	int weaponLevel
	*/
	//Uses player pref which sotres 
	public void SaveState() { 
		PlayerPrefs.SetInt("playerSkin", 0);
		PlayerPrefs.SetInt("playerRubies", rubies.getRubies());
		PlayerPrefs.SetInt("playerExperience", experience);
	}//end method

	//Loading the game
	public void LoadState(Scene s, LoadSceneMode mode) {

		//Make sure the save keys exists.
		if (!(PlayerPrefs.HasKey("playerSkin") && PlayerPrefs.HasKey("playerRubies") && PlayerPrefs.HasKey("playerExperience") && PlayerPrefs.HasKey("weaponLevel")))
			return;

		//Change player skin

		//rubies
		//rubies.setRubies(PlayerPrefs.GetInt("playerRubies")); 

		//Expereince
		experience = PlayerPrefs.GetInt("playerExperience");

		Debug.Log("LoadState");
	}//end method
	
	//Called once when the gameobject that contains this script is loaded.
	void Awake() {
		if (GameManager.instance != null) {
			Destroy(gameObject);
			return;
		}//end if

		DontDestroyOnLoad(gameObject);
		instance = this;
		instance.rubies = gameObject.AddComponent<playerRubies>();

		//subscribe load and save state functions to events in SceneManager
		//These are called when the scene is loaded/unloaded respectively
		//SceneManager.sceneLoaded += LoadState;

	}//end method
}
