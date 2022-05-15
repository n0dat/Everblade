using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource music;

    private void Start(){
        DontDestroyOnLoad(gameObject);

        if(FindObjectsOfType<AudioManager>().Length > 1)
            Destroy(gameObject);
    }

    public void changeMusic(AudioClip newMusic){

        // will check if the audio clip that is gonna want to 
        // try to play is already playing and if it is it won't do anything
        if(music.clip.name == newMusic.name)
            return;

        music.Stop();
        music.clip = newMusic;
        music.Play();
    }
}
