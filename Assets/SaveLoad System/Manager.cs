using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

    public TransferPlayerData ManagerData;
    public Animator transition;

    public GameObject CharacterSpawner;

    public GameObject ScoreSpawner;

    public GameObject MiniMapSpawner;
    MiniMapFollow MiniMapFollow;

    public ThirdPersonController controller;

    public bool flag;


    void Start(){
        ManagerData = GetComponent<TransferPlayerData>();
        transition = GetComponent<Animator>();
        flag = false;
    }

    public void LoadData() {
        PlayerData data = SaveLoadSYSTEM.Load();
        
        ManagerData.level = data.level;
        ManagerData.score = data.score;
        
        ManagerData.trans[0] = data.position[0];
        ManagerData.trans[1] = data.position[1];
        ManagerData.trans[2] = data.position[2];

        StartCoroutine(LoadSavedLevel(ManagerData.level, ManagerData.score, ManagerData.trans));
        flag = true;
    }

    IEnumerator LoadSavedLevel(int LevelIndex, int Score, float[] trans) {
        if(SceneManager.GetActiveScene().buildIndex != 3){
            transition.SetTrigger("Start");
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(LevelIndex);
            yield return new WaitForSeconds(3);
        
            Instantiate(ScoreSpawner);
            Coin_Collection.setScore(Score);

            Instantiate(CharacterSpawner);

            Instantiate(MiniMapSpawner);
            MiniMapFollow = GameObject.Find("Mini Map Camera").GetComponent<MiniMapFollow>();
            MiniMapFollow.Player = this.transform;
        }
        
    }

}
