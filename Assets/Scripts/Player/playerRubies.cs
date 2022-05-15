using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRubies : MonoBehaviour {

    public int totalRubies;
    
    public int getRubies() {
        return totalRubies;
    }

    private void setRubies(int rubiesToSet) {
        totalRubies = rubiesToSet;
    }
    public void addRubies(int rubiesToAdd) {
        if (rubiesToAdd <= 0) {
            Debug.Log("Unable to add " + rubiesToAdd + " rubies.");
            return;
        }
        else {
            totalRubies += rubiesToAdd;
            Debug.Log("Added " + rubiesToAdd + " rubies to player total.");
        }
    }
    
    public void removeRubies(int rubiesToRemove) {
        if (rubiesToRemove <= 0) {
            Debug.Log("Unable to add " + rubiesToRemove + " rubies.\nIncorrect Function, refer to addRubies()");
            return;
        }
        else {
            totalRubies -= rubiesToRemove;
            Debug.Log("Removed " + rubiesToRemove + " rubies from player total.");
        }
    }
    
}
