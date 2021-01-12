using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Goal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

	void Update () {
        transform.Rotate(new Vector3(0f, 100f, 0f) * Time.deltaTime);
	}
}
