using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {

    [Range(0, 3)]
    public float GameSpeed;

	// Use this for initialization
	void Start () {
        GameSpeed = 1f;
	}
	
	// Update is called once per frame
	void Update () {
        Time.timeScale = GameSpeed;
	}
}
