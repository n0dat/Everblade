using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText
{
    public bool isActive;
    public GameObject myGameObject;
    public Text txt;
    public Vector3 motion;
    public float duration;
    public float lastShown;

    public void Show()
    {
    	isActive = true;
    	lastShown = Time.time;
    	myGameObject.SetActive(isActive);
    }

    public void HideText()
    {
    	isActive = false;
    	myGameObject.SetActive(isActive);
    }

    public void UpdateFloatingText()
    {
    	if(!isActive)
    		return;

    	//Only show for a ceratin amount of time.
    	if(Time.time - lastShown > duration)
    		HideText();

    	myGameObject.transform.position += motion * Time.deltaTime;
    }

 
 }
