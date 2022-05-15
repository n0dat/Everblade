using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class doorManager : Collidable {
	
	public SpriteRenderer spriteRenderer;
	public Sprite openSprite;
	
	public BoxCollider2D bc2;
	
	public float messageLength;
	
	public bool isOpen;
	public bool canBeOpened;
	public bool hasCollided;
	public bool hasPressedE;
	
	public GameObject doorMessage;
	
	void ChangeSprite() {
		spriteRenderer.sprite = openSprite;
	}
	

    void Start() {
		hasPressedE = false;
        isOpen = false;
		canBeOpened = false;
		hasCollided = false;
		messageLength = 2.0f;
		doorMessage.GetComponent<TextMeshPro>().text = "Press 'e' to open";
    }
	

	private IEnumerator DisplayMessage(float time) {

		yield return new WaitForSeconds(time);
		doorMessage.SetActive(false);
	}
	
	
	protected override void OnCollide(Collider2D hitCollider) {

		Debug.Log("door colliding with: " + hitCollider.name);
		if (hitCollider.name == "Player") {
			if (Input.GetKeyDown(KeyCode.E)) {
				StopCoroutine("DisplayMessage");
				doorMessage.SetActive(false);

				if (!isOpen && player.GetComponent<playerKeys>().getKeys() > 0) {
					player.GetComponent<playerKeys>().removeKeys(1);
					Debug.Log("Door opened");
					ChangeSprite();
					bc2.enabled = false;
				}

				else if (!isOpen && player.GetComponent<playerKeys>().getKeys() < 1) {
					doorMessage.GetComponent<TextMeshPro>().text = "You need a key";
					if (!hasPressedE) {
						doorMessage.transform.position = new Vector3(doorMessage.transform.position.x + 0.01f, doorMessage.transform.position.y, doorMessage.transform.position.z);
						hasPressedE = true;
					}
					doorMessage.SetActive(true);
					StartCoroutine(DisplayMessage(messageLength));
				}
			}

			else {
				doorMessage.SetActive(true);
				StartCoroutine(DisplayMessage(messageLength));
			}
		}
	}
}