using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public static bool isPaused = false;
    public GameObject PauseUI;

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused){
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume(){
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void LoadMenu(){
        SceneManager.LoadScene(0);
    }

    public void Exit(){
        Application.Quit();
    }

    void Pause(){
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
}
