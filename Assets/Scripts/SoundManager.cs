using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

	public AudioFile[] AudioFiles;
	public AudioSource sounds;

	private PlaneManager planeManager;
	public bool played;
	
	// Use this for initialization
	void Start ()
	{
		PlaneSound();
		planeManager = GameObject.FindWithTag("Plane").GetComponent<PlaneManager>();
	}
	
	// Update is called once per frame
	void Update()
	{
		UpdateSound("brace");
	}

	void PlaneSound()
	{
		sounds.clip = GetAudioFile("plane-sound");
		sounds.loop = true;
		sounds.Play();
	}

	void UpdateSound(string name)
	{
		sounds.clip = GetAudioFile(name);
		sounds.loop = false;
		sounds.PlayOneShot(sounds.clip, 1);
	}


	AudioClip GetAudioFile(string name)
	{

		for (int i = 0; i < AudioFiles.Length; i++)
		{
			if (AudioFiles[i].AudioName == name)
			{
				return AudioFiles[i].ClipPath;
			}
		}

		return null;
	}
}
