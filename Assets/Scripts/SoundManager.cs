using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;

	public AudioFile[] AudioFiles;

	private PlaneManager planeManager;
	public bool played;

    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start ()
	{
		planeManager = GameObject.FindWithTag("Plane").GetComponent<PlaneManager>();
	}
	
	// Update is called once per frame
	void Update()
	{
	}

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
