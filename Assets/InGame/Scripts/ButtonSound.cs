using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource soundPlay;
    public void PlaySound()
    {
        soundPlay.Play();
    }
}
