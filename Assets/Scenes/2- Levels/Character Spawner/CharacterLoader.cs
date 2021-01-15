using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLoader : MonoBehaviour {
    public GameObject[] charactersPrefabs;
    public GameObject prefab;
    
    void Start() {
        int selectedCharacter = PlayerPrefs.GetInt("SelectedChar");
        prefab = charactersPrefabs[selectedCharacter];
        prefab = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
