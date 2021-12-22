using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static void Play_LevelCompletion()
    {
        Singleton.instance.levelCompletionSound.Play();
    }

    public static void ToggleMusic()
    {
        if (Singleton.instance.musicON)
        {
            Singleton.instance.music.Stop();
        }
        else
        {
            Singleton.instance.music.Play();
        }
        Singleton.instance.musicON = !Singleton.instance.musicON;
    }
}
