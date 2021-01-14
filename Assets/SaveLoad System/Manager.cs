using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

    TransferPlayerData playerData;
    CharacterLoader Characterloader;
    public Animator transition;
    public GameObject CharacterSpawner;
    public GameObject ScoreSpawner;

    void Start(){
        playerData = GetComponent<TransferPlayerData>();
        transition = GetComponent<Animator>();
    }
    public void SaveData() {
        SaveLoadSYSTEM.Save(playerData); //script is on the player it self
    }

    public void LoadData() {
        PlayerData data = SaveLoadSYSTEM.Load();

        playerData.level = data.level;
        playerData.score = data.score;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        playerData.transform.position = position;

        //Debug.Log("Loaded, level:" + playerData.level + " Score: " + playerData.score +
        //              " position:" + position.x + " " + position.y + " "+ position.z);

        StartCoroutine(LoadSavedLevel(playerData.level, playerData.score));
    }

    IEnumerator LoadSavedLevel(int LevelIndex, int Score) {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(LevelIndex);
        yield return new WaitForSeconds(3);
        if(LevelIndex != 2){
            Instantiate(ScoreSpawner);
            Coin_Collection.setScore(Score);
            Instantiate(CharacterSpawner);
            Characterloader = CharacterSpawner.GetComponent<CharacterLoader>();
            Instantiate(Characterloader.prefab, playerData.transform.position, Quaternion.identity);
        }
    }

}
