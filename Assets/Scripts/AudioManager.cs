using System;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip coinClip;
    private void Awake()
    {
        audioSource = this.GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);        
    }



    public void PlayCoinClip()
    {
        this.audioSource.PlayOneShot(this.coinClip);
    }
}
