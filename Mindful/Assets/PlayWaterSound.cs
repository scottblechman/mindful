using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayWaterSound : MonoBehaviour {
    public List<AudioClip> sounds;
    public AudioSource player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playSound()
    {
        int listSize = sounds.Capacity;
        int indexToPlay = (int)Random.Range(0, listSize);
        player.PlayOneShot(sounds[indexToPlay]);
    }
}
