using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource lightEffectSource;
    public AudioSource buttonClickSource;
    public AudioSource doorCloseSource;
    public AudioSource doorOpenSource;

    public void playLightEffect ()
    {
        lightEffectSource.Play();
    }

    public void playButtonClick ()
    {
        buttonClickSource.Play();
    }

    public void playDoorEffect (bool open)
    {
        if (open)
        {
            doorOpenSource.Play();
        } else
        {
            doorCloseSource.Play();
        }
    }
}
