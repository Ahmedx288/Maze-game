using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Complete : MonoBehaviour {
    private AudioSource mAudioSource = null;
    public AudioClip CoinSound = null;
    LevelLoader LevelLoader;
    // Start is called before the first frame update
    void Start() {
        mAudioSource = GetComponent<AudioSource>();
        LevelLoader = GameObject.Find("Level_Loader").GetComponent<LevelLoader>();
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

    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoad;
    }
    //Get the new loader from the next scene (Refresh pointed Objects)
    void OnSceneLoad(Scene scene, LoadSceneMode mode) {
        LevelLoader = GameObject.Find("Level_Loader").GetComponent<LevelLoader>();
        mAudioSource = GetComponent<AudioSource>();
    }
}
