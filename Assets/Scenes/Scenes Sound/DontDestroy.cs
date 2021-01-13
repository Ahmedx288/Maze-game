using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    void Awake(){
        //This Step to prevent more than one sound object to be loaded if we go back to the Menu scene;
        GameObject[] soundObjs = GameObject.FindGameObjectsWithTag("BG_MUSIC");
        if(soundObjs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }
}
