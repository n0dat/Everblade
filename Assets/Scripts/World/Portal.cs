using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : Collidable
{
	public string sceneName;
	public Vector3 teleportLocation;
	
	//public string sceneLoad = SceneManager.GetSceneByName();
    // Start is called before the first frame update
	protected override void OnCollide(Collider2D hitCollider)
	{
		/*if (hitCollider.name == "Player")
		{
			//LoadScene loads scenes from build settings.
			UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName); //This is how you change scenes in unity. IMPORTANT
			GameObject.Find("Player").transform.position = initialTeleportLocation;
		}*/

		if (hitCollider.name == "Player"){
			Debug.Log("loading " + sceneName);
			GameManager.LoadGameScene(sceneName);
			player.transform.position = teleportLocation;
		}

	}
}
