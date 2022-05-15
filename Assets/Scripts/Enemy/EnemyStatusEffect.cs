using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatusEffect : MonoBehaviour{


    public List<int> tickTimer = new List<int>();
    float damage = 5f;

    public GameObject poisonEffect;
    public GameObject burnEffect;
    public float timesHit = 0f;
    public float neededHits;

    public GameObject enemy;
    //public GameObject enemyHealth;

    public void applyBurn(int ticks){
        if(tickTimer.Count <= 0){
            tickTimer.Add(ticks);
            StartCoroutine(burn());
        }
        else{
            tickTimer.Add(ticks);
        }
    }

    IEnumerator burn(){
        
        while(tickTimer.Count > 0){
            for(int i = 0; i < tickTimer.Count; i++){
                tickTimer[i]--;
            }
            //playerHealth.playerHealthInstance.UpdateHealth(-damage); 
            //Instantiate(burnEffect, transform.position, Quaternion.identity);
            tickTimer.RemoveAll(i => i == 0);// remove i in the case that i is zero
            yield return new WaitForSeconds(1f);
        }
    }

    public void applyPoison(int ticks){
        timesHit++;
        if(tickTimer.Count <= 0){
            tickTimer.Add(ticks);
            StartCoroutine(poison());
        }
        else{
            tickTimer.Add(ticks);
        }
    }

    IEnumerator poison(){
        
        while(tickTimer.Count > 0){
            for(int i = 0; i < tickTimer.Count; i++){
                tickTimer[i]--;
                Debug.Log("this should be happenign some amount of time");
            }
            if(timesHit >= neededHits){
                enemy.GetComponent<enemyBehavior>().UpdateHealth(-5);
                Instantiate(poisonEffect, transform.position, Quaternion.identity);
            }
            tickTimer.RemoveAll(i => i == 0);// remove i in the case that i is zero
            yield return new WaitForSeconds(1f);
        }
        timesHit = 0f;
    }
}
