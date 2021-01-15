using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UpdatePlayerData : MonoBehaviour
{
    TransferPlayerData data;
    private float nextActionTime = 0.0f;
    public float period = 3f;

    void Start(){
        data = GetComponent<TransferPlayerData>();
    }

    void Update() {
        if (Time.time > nextActionTime)
        {
            data.score = Coin_Collection.score;
            data.level = SceneManager.GetActiveScene().buildIndex;
            data.trans[0] = transform.position.x;
            data.trans[1] = transform.position.y; 
            data.trans[2] = transform.position.z;

            SaveLoadSYSTEM.Save(data);
        }
    }
}
