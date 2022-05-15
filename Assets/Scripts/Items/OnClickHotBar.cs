
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnClickHotBar : MonoBehaviour {
	/*
	public GameObject itemObject;
	public string buttonName = "CurePoisonButton";
	//public Inventory inventory;
	*/
	/*
	void Start() {
		buttonName = "";
	}
	*/
	/*
	private void runButton() {
		//string  = this.buttonName;
		if (this.buttonName != "")
			//GetComponent<Type.GetType(this.buttonName)>().OnButtonPress();
			(GetComponent(this.buttonName)).OnButtonPress();
	}
	
	public virtual void OnPointerClick(PointerEventData eventData) {
		if (eventData.button == PointerEventData.InputButton.Left) {
			runButton();	
		}
		else if (eventData.button == PointerEventData.InputButton.Right)
			//inventory.Add(item);
			itemObject.GetComponent<ItemPickup>().PickUp();
			Destroy(transform.gameObject);
			
	}
	*/
}
