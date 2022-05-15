using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignManager : MonoBehaviour {

	public GameObject[] signs;
	GameObject player;
		
	void Start() {
		player = GameObject.Find("Player");
		if (signs.Length != 0) {
			foreach (GameObject sign in signs)
				sign.SetActive(false);
		}
	}
	
	public void openMenu(int index) {
		signs[index].SetActive(true);
	}
	
	public void closeMenu(int index) {
		signs[index].SetActive(false);
	}
}