using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour {
	public GameObject[] slots;
	public bool[] isUsed;
	public static Hotbar playerHotbarInstance;

	public void Start() {
		playerHotbarInstance = this;
	}
}
