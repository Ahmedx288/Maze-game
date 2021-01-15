using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpdateHighestScore : MonoBehaviour {

    Text high;

    // Start is called before the first frame update
    void Start() {
        high = GameObject.Find("ActualScore").GetComponent<Text>();

        if(PlayerPrefs.GetInt("Highest",0) > int.Parse(high.text)){
            high.text = PlayerPrefs.GetInt("Highest",0).ToString();
        }

    }

    public void reset(){
        PlayerPrefs.SetInt("Highest", 0);
        high.text = PlayerPrefs.GetInt("Highest",0).ToString();
    }
}
