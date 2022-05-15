using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_player : MonoBehaviour {

	GameObject thePlayer;
	GameObject theCamera;

	float deltaX;
	private float deltaY;
    
    void Start() {	
        //DontDestroyOnLoad(gameObject);
		Application.targetFrameRate = 60;
        thePlayer = GameObject.Find("Player");
        transform.position = new Vector3(thePlayer.transform.position.x, thePlayer.transform.position.y, transform.position.z);
		GameManager.LoadGameScene("Overworld");
		GameManager.LoadGameScene("House1");
		GameManager.LoadGameScene("Dungeon7");
    }

    void Update() {	//transform is a property of MonoBehavior, thats why its accesable. When follow_player object is instanciated, transform var is set to refer to transform var in GameObject. You can also just get a ref to the game object and directly reference it through that.
        //transform.position = new Vector3(thePlayer.transform.position.x, thePlayer.transform.position.y, transform.position.z);
    	//Difference between camera and character position.
    	deltaX = thePlayer.transform.position.x - transform.position.x;
    	deltaY = thePlayer.transform.position.y - transform.position.y;

    	if (deltaX > 0.30)
    		transform.Translate((float) (deltaX - 0.30), 0, 0);
    	else if(deltaX < -0.30)
    		transform.Translate((float) (deltaX + 0.30), 0, 0);

    	if (deltaY > 0.30)
    		transform.Translate(0, (float) (deltaY - 0.30), 0);
    	else if(deltaY < -0.30)
    		transform.Translate(0, (float) (deltaY + 0.30), 0);

    }
}
