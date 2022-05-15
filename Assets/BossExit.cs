using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossExit : MonoBehaviour {
	
	public GameObject boss;
	public GameObject portal;
	
	void Start() {
		portal.SetActive(false);
	}
	
	void Update() {
		if (boss == null) {
			portal.SetActive(true);
			Destroy(gameObject);
		}
	}
}