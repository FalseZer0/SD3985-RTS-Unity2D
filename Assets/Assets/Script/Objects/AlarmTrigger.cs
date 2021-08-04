using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    AudioSource alarmSound;
    public bool On;
    public bool Deactivated;
    

    void Start()
    {
        On = false;
        Deactivated = false;
        alarmSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Deactivated == false)
        {
            if (On == true && alarmSound.isPlaying == false)
            {
                alarmSound.Play();
            }
        }
    }
}
