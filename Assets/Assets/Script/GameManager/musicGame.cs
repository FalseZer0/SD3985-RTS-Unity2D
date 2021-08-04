using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicGame: MonoBehaviour
{
   private AudioSource menuAudio;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        menuAudio = GetComponent<AudioSource>();
    }

    public void gamePlayMusic()
    {
        if (menuAudio.isPlaying) return;
        menuAudio.Play();
    }

    public void gameStopMusic()
    {
        if (!menuAudio.isPlaying) return;
        menuAudio.Stop();
    }
}

