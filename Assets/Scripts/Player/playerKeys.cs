using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerKeys : MonoBehaviour {

    private int totalKeys;
    
    public int getKeys() {
        return totalKeys;
    }

    private void setKeys(int KeysToSet) {
        totalKeys = KeysToSet;
    }
    public void addKeys(int KeysToAdd) {
        if (KeysToAdd <= 0) {
            Debug.Log("Unable to add " + KeysToAdd + " Keys.");
            return;
        }
        else {
            totalKeys += KeysToAdd;
            Debug.Log("Added " + KeysToAdd + " Keys to player total.");
        }
    }
    
    public void removeKeys(int KeysToRemove) {
        if (KeysToRemove <= 0) {
            Debug.Log("Unable to add " + KeysToRemove + " Keys.\nIncorrect Function, refer to addKeys()");
            return;
        }
        else {
            totalKeys -= KeysToRemove;
            Debug.Log("Removed " + KeysToRemove + " Keys from player total.");
        }
    }
    
}
