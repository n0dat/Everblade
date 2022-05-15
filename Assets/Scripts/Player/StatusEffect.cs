using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect : MonoBehaviour{

    public List<int> tickTimer = new List<int>();
    public List<int> tickTimerManaPot = new List<int>();
    public List<int> tickTimerHealthPot = new List<int>();

    public bool hasHealthTick = false;
    public bool hasManaTick = false;
    public bool counterPoison = false;

    public GameObject poisonEffect;
    public GameObject burnEffect;

    public float timesHit = 0f;
    public float neededHits;

    public float healingRate;
    public float restoreManaRate;
    float damage = 5f;

    void Update(){
        if(hasHealthTick){
            InvokeRepeating("overTimeHealingArmor", 1.0f, 3.0f);
        }
        if(hasManaTick){
            InvokeRepeating("overTimeManaResoreArmor", 1.0f, 3.0f);
        }
    }

    public void overTimeHealingArmor(){
        if(!hasHealthTick)
            return;
        playerHealth.playerHealthInstance.UpdateHealth(healingRate); 
    }

    public void overTimeManaResoreArmor(){
        if(!hasManaTick)
            return;
        playerMana.playerManaInstance.UpdateMana(restoreManaRate); 
    }

    public void applyHealingOverTimePot(int ticks){
        if(tickTimerHealthPot.Count <= 0){
            tickTimerHealthPot.Add(ticks);
            StartCoroutine(heal());
            counterPoison = false;
        }
        else{
            tickTimerHealthPot.Add(ticks);
        }
    }
    public void applyManaOverTimePot(int ticks){
        if(tickTimerManaPot.Count <= 0){
            tickTimerManaPot.Add(ticks);
            StartCoroutine(mana());
            counterPoison = false;
        }
        else{
            tickTimerManaPot.Add(ticks);
        }
    }

    public void applyBurn(int ticks){
        if(tickTimer.Count <= 0){
            tickTimer.Add(ticks);
            StartCoroutine(burn());
            counterPoison = false;
        }
        else{
            tickTimer.Add(ticks);
        }
    }

    IEnumerator heal(){
        while(tickTimerHealthPot.Count > 0){
            for(int i = 0; i < tickTimerHealthPot.Count; i++){
                tickTimerHealthPot[i]--;
            }
            playerHealth.playerHealthInstance.UpdateHealth(3); 
            tickTimerHealthPot.RemoveAll(i => i == 0);// remove i in the case that i is zero
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator mana(){
        while(tickTimerManaPot.Count > 0){
            for(int i = 0; i < tickTimerManaPot.Count; i++){
                tickTimerManaPot[i]--;
            }
            playerMana.playerManaInstance.UpdateMana(3); 
            tickTimerManaPot.RemoveAll(i => i == 0);// remove i in the case that i is zero
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator burn(){
        
        while(tickTimer.Count > 0){
            for(int i = 0; i < tickTimer.Count; i++){
                tickTimer[i]--;
            }
            playerHealth.playerHealthInstance.UpdateHealth(-damage); 
            Instantiate(burnEffect, transform.position, Quaternion.identity);
            tickTimer.RemoveAll(i => i == 0);// remove i in the case that i is zero
            yield return new WaitForSeconds(1f);
        }
    }

    public void applyPoison(int ticks){
        timesHit++;
        if(tickTimer.Count <= 0){
            tickTimer.Add(ticks);
            StartCoroutine(poison());
            counterPoison = false;
        }
        else{
            tickTimer.Add(ticks);
        }
    }

    IEnumerator poison(){
        
        while(tickTimer.Count > 0){
            for(int i = 0; i < tickTimer.Count; i++){
                tickTimer[i]--;
                if(counterPoison)
                    break;
                Debug.Log("this should be happenign some amount of time");
            }
            if(timesHit >= neededHits){
                playerHealth.playerHealthInstance.UpdateHealth(-damage); 
                Instantiate(poisonEffect, transform.position, Quaternion.identity);
            }
            if(counterPoison){
                playerHealth.playerHealthInstance.UpdateHealth(+damage); 
            }
            tickTimer.RemoveAll(i => i == 0);// remove i in the case that i is zero
            yield return new WaitForSeconds(1f);
        }
        timesHit = 0f;
    }
}
