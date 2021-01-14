using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniMapFollow : MonoBehaviour {
    
    public Transform Player;

    // Update is called once per frame
    void LateUpdate() {
        Vector3 newPosition = Player.position;
        newPosition.y = transform.position.y; //save camera height;
        transform.position = newPosition;
    }

}
