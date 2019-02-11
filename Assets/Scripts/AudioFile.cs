using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SerializeField]
public class AudioFile 
{

    public string AudioName;
    public AudioClip ClipFile;

    public AudioFile(string name, AudioClip audio)
    {
        AudioName = name;
        ClipFile = audio;
    } 

}
