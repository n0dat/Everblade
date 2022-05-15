using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RubyCounter : MonoBehaviour {
	
	public GameObject player;
	public Text rCounter;
	public Text kCounter;
	
	void Start() {
		player = GameObject.FindWithTag("Player");
	}

    void Update() {
        rCounter.text = ("" + player.GetComponent<playerRubies>().getRubies());
		kCounter.text = ("" + player.GetComponent<playerKeys>().getKeys());
    }
}
