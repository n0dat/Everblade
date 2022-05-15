using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable {
	protected bool collected; // Protected means its private to everyone except children of this class.

	protected override void OnCollide(Collider2D myCollider) {
		if (myCollider.gameObject.tag == "Player")
			OnCollect();
	}

	protected virtual void OnCollect() {
		collected = true;
	}
}
