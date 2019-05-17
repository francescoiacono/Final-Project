using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controlling sounds

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance; // NB: THIS VARIABLE WAS USED IN THE PROTOTYPE
    public AudioFile[] AudioFiles; // All audiofiles stored in this array that can be updated in the inspector

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        // Running all the sounds from the beginning        
        StartCoroutine(WaitToPlaySound("plane-sound", 0, 345, 0.3f, 120));
        StartCoroutine(WaitToPlaySound("people-sound", 0, 121, 0.3f, 0));
        StartCoroutine(WaitToPlaySound("captain-brace", 300, 305, 1, 0));
        StartCoroutine(WaitToPlaySound("crew-brace", 305, 38, 1, 0));
        StartCoroutine(WaitToPlaySound("water-sound", 345, 32, 1, 0));
        StartCoroutine(WaitToPlaySound("birds-sound", 120, 137, 1, 0));
    }


    // Function to play a determined sound once
    public void PlaySound(string name)
    {
        AudioFile af = GetAudioFile(name);
        if (af != null)
        {
            if (!af.played)
            {
                af.AudioSource.Play();
                af.played = true;
            }
        }
    }

    // Function to stop a determined sound
    public void StopSound(string name)
    {
        AudioFile af = GetAudioFile(name);
        if (af != null)
        {
            if (af.played)
            {
                af.AudioSource.Stop();
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

    // Main function which will wait a certain time to play the sound
    // after a certain period the volume sound will be changed or not
    // after a certain duration the sound will stop
    IEnumerator WaitToPlaySound(string name, float time, float duration, float volume, float volumeTime) {

        yield return new WaitForSeconds(time);
        PlaySound(name);
        yield return new WaitForSeconds(volumeTime);
        GetAudioFile(name).AudioSource.volume = volume;
        yield return new WaitForSeconds(duration);
        StopSound(name);

    }


}
