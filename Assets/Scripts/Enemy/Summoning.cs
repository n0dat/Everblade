using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoning : MonoBehaviour{

    public Transform summoner;
    public float howFar = 0.2f;
    public float distanceToPlayer;
    int randNum;

    public GameObject demon1;
    public GameObject demon2;
    public GameObject demon3;
    public GameObject demon4;

    public GameObject summoningEffect;

    public List<int> tickTimer = new List<int>();
    public int ticks;

    void Update() {
        if (Vector3.Distance(GameObject.Find("Player").transform.position, transform.position) < distanceToPlayer){
            if (tickTimer.Count <= 5)
                applySummon(4);
        }
    }

    public void applySummon(int tick){
        if(tickTimer.Count <= 0){
            tickTimer.Add(ticks);
            StartCoroutine(SummoningEnemies());
        }
        else{
            tickTimer.Add(ticks);
        }
    }

    IEnumerator SummoningEnemies(){
        while(tickTimer.Count > 0){
            Vector3 placeToSpawn = summoner.position;
            placeToSpawn.y = placeToSpawn.y + howFar;
            randNum = Random.Range(1,4);
            for(int i = 0; i < tickTimer.Count; i++){
                tickTimer[i]--;
            }
            if(randNum == 1){
                Object.Instantiate(demon3, placeToSpawn, Quaternion.identity);
            }
            if(randNum == 2){
                Object.Instantiate(demon2, placeToSpawn, Quaternion.identity);
            }
            if(randNum == 3){
                Object.Instantiate(demon3, placeToSpawn, Quaternion.identity);
            }
            if(randNum == 4){
                Object.Instantiate(demon4, placeToSpawn, Quaternion.identity);
            } 
            Instantiate(summoningEffect, placeToSpawn, Quaternion.identity);
            tickTimer.RemoveAll(i => i == 0);// remove i in the case that i is zero
            yield return new WaitForSeconds(5f);
        }     
    }
}