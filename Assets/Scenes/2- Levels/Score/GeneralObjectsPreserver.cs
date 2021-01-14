using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralObjectsPreserver : MonoBehaviour {
    void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
}
