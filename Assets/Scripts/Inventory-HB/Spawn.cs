using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

	public GameObject itemToDrop;
	public Transform playerTransform;
	public float howFar = 0.2f;

	public void Start() {
		playerTransform = GameObject.Find("Player").transform; //Find the player transform.
	}

	public void SpawnDroppedItem() {
		Vector3 placeToSpawn = playerTransform.position;
		placeToSpawn.y = placeToSpawn.y + howFar;
		Object.Instantiate(itemToDrop, placeToSpawn, Quaternion.identity);
	}
}
