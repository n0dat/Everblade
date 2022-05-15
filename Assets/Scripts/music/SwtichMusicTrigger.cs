using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwtichMusicTrigger : MonoBehaviour
{

    public AudioClip newTrack;
    private AudioManager AM;
    // Start is called before the first frame update
    void Start()
    {
        AM = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collided){
        if(collided.tag == "Player"){
            if(newTrack != null)
                AM.changeMusic(newTrack);
        }
    }

}
