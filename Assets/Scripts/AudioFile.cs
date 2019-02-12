using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class AudioFile
{

    public string AudioName;
    public AudioSource AudioSource;
    [HideInInspector] public bool played;

}
