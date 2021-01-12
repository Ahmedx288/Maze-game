using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin_Collection : MonoBehaviour
{   
    private AudioSource mAudioSource = null;
    public AudioClip CoinSound = null;

    private static int score = 0;
    private Text scoreText;


    // Start is called before the first frame update
    void Start()
    {
        mAudioSource = GetComponent<AudioSource>();
        scoreText = GameObject.Find("Score_Text").GetComponent<Text>();
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag.Equals("Coin")) {
            score++;
            scoreText.text = "Score: " + score;

			if(mAudioSource != null && CoinSound != null){
				mAudioSource.PlayOneShot(CoinSound);
			}
			Destroy(other.gameObject);
		}
	}
}
