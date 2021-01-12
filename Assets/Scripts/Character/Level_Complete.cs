﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Complete : MonoBehaviour
{
    private AudioSource mAudioSource = null;
    public AudioClip CoinSound = null;
    LevelLoader LevelLoader;
    // Start is called before the first frame update
    void Start()
    {
        mAudioSource = GetComponent<AudioSource>();
        LevelLoader = GameObject.Find("Level_Loader").GetComponent<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag.Equals("Maze_Key")) {
			Destroy(other.gameObject);

            if(mAudioSource != null && CoinSound != null){
				mAudioSource.PlayOneShot(CoinSound);
			}

            LevelLoader.LoadNextLevel();
        }
	}
}