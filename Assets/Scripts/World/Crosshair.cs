using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {
    
    public GameObject crossHair;
    // Update is called once per frame
    void Start() {
        //Cursor.visible = false;
    }
    
    void Update() {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, 10);
    }
}
