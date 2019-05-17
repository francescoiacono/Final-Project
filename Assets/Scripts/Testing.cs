using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {

    // Script used to make the testing faster
    // It basically increase the speed of the gameplay through a slider in the inspector

    [Range(0, 10)]
    public float GameSpeed;

	void Start () {
        GameSpeed = 1f;
	}
	
	void Update () {
        Time.timeScale = GameSpeed;
	}
}
