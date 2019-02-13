using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controlling sounds

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance; // test, TODO instance test
    public AudioFile[] AudioFiles; // All audiofiles stored in this array that can be updated in the inspector


	private PlaneManager planeManager;

    void Awake()
    {
        Instance = this; 
    }

    void Start ()
	{
		planeManager = GameObject.FindWithTag("Plane").GetComponent<PlaneManager>();
	}


    // Function to play a determined sound once
    public void PlaySound(string name)
    {
        AudioFile af = GetAudioFile(name);
        if (af != null)
        {
            if(!af.played)
            {
                af.AudioSource.Play();
	            af.played = true;
            }
        }
    }

    // Function that gets the audiofile name and if it matches return that audiofile
	AudioFile GetAudioFile(string name)
	{

		for (int i = 0; i < AudioFiles.Length; i++)
		{
			if (AudioFiles[i].AudioName == name)
			{
				return AudioFiles[i];
			}
		}

		return null;
	}
}
