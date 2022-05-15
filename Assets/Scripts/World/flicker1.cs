using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flicker1 : MonoBehaviour {
	private SpriteRenderer spriterenderer;
	private float elapsedTime;
	public Sprite[] spritecollection;
	private int i;

	void incrementI() {
		if (i == 6)
			i = 0;
		else
			i++;
	}

    // Start is called before the first frame update
    void Start() {
        spriterenderer = gameObject.GetComponent<SpriteRenderer>();
        elapsedTime = 0;
        i = 1;
    }

    // Update is called once per frame
    void Update() {
        elapsedTime = elapsedTime + Time.deltaTime;
		
		// A second has elapsed
        if ( elapsedTime >= 1) {
        	spriterenderer.sprite = spritecollection[i];
        	incrementI();
        	elapsedTime = 0;
        }

        	
    }
}
