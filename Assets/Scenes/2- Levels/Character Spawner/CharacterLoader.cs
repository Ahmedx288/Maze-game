using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLoader : MonoBehaviour {
    public GameObject[] charactersPrefabs;
    
    void Start() {
        int selectedCharacter = PlayerPrefs.GetInt("SelectedChar");
        GameObject prefab = charactersPrefabs[selectedCharacter];
        Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
