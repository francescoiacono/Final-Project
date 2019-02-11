using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
		transform.GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
