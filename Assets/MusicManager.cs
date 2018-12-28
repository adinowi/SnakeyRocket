using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour {
    public AudioClip MenuMusic;
    public AudioClip PlayingMusic;
    private bool chanageState;
    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        chanageState = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = MenuMusic;
        audioSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
        if(GameManager.state == GameState.Playing && audioSource.clip == MenuMusic)
        {
            audioSource.Stop();
            audioSource.clip = PlayingMusic;
            audioSource.Play();         
        }
        if (GameManager.state != GameState.Playing && audioSource.clip == PlayingMusic)
        {
            audioSource.Stop();
            audioSource.clip = MenuMusic;
            audioSource.Play();
        }
    }
}
