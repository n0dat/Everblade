using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour{

    #region Singleton

    // doing this shoudl allow you to interact with one inventory at all times?? I have no idea, brackeys 
    public static Inventory instance;

    void Awake(){
        if (instance != null){
            Debug.LogWarning("more than one instance of inventory found!");
            return;
        }
        instance = this;
    }
    #endregion

    public delegate void OnItemChanged();

    // i think OnItemChangedCallback, it works as an event, so if something does change with
    // the inventory, then the UI is gonna change accordingly 
    public OnItemChanged OnItemChangedCallback;

    public List<Item> items = new List<Item>();

    public int space = 20;

    private Transform player;

    // will add items to inventory if there is enough room and the, there is only 
    // one instance of an inventory, and if the callback isn't null 
    public bool Add (Item item){
        if(!item.isDefaultItem){
            if (items.Count >= space){
                Debug.Log("not enough room");
                return false;
            }
            items.Add(item);

            if (OnItemChangedCallback != null){
                OnItemChangedCallback.Invoke();
            }
        }
        return true;
    }

    public void Remove (Item item){

        /*player = Player.playerInstance.transform;

        Vector2 playerPos = new Vector2(player.position.x, player.position.y + 3);
        Instantiate(item, playerPos, Quaternion.identity);
        */
        

        items.Remove(item);

        if (OnItemChangedCallback != null){
                OnItemChangedCallback.Invoke();
        }
    }
}
