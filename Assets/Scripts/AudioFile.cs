using UnityEngine;

// Class for AudioFile objects:
// Name of the audio, AudioSouce to use, boolean to play sound once.

[System.Serializable]
public class AudioFile
{

    public string AudioName;
    public AudioSource AudioSource;
    [HideInInspector] public bool played;

}
