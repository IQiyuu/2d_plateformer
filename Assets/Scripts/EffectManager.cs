using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{

    [SerializeField] AudioSource aSource;

    public void playSound() {
        if (aSource.isPlaying)
            aSource.Stop();
        aSource.Play();
    }

    public void stopSound() {
        if (aSource.isPlaying)
            aSource.Stop();
    }

    public void UpdateVolume(float volume) {
        aSource.volume = volume;
    }
}