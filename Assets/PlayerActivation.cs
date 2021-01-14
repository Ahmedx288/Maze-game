using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActivation : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(PlayerPrefs.GetInt("SelectedChar")).gameObject.SetActive(true);
    }
}
