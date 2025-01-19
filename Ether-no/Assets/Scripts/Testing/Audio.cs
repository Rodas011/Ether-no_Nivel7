using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]

public class Audio 
{
   public string name;
   public AudioClip audioFile;

    [Range(0, 1f)]
   public float volume;
    [Range(0.1f, 2f)]
   public float pitch;

   public bool loop;

   [HideInInspector]
   public AudioSource source; 

}
