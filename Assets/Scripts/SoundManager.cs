using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

	public AudioClip[] AudioClips;
	
	// Use this for initialization
	void Start ()
	{
		transform.GetComponent<AudioSource>().clip = AudioClips[0];
		transform.GetComponent<AudioSource>().loop = true;
		transform.GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
