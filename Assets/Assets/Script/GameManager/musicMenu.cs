using UnityEngine;

public class musicMenu : MonoBehaviour
{
    private AudioSource menuAudio;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        menuAudio = GetComponent<AudioSource>();
    }

    public void menuPlayMusic()
    {
        if (menuAudio.isPlaying) return;
        menuAudio.Play();
    }

    public void menuStopMusic()
    {
        menuAudio.Stop();
    }
}