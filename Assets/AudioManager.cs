using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
     [SerializeField] AudioSource SFXSource;

    public AudioClip bark;
    public AudioClip cricket;
    //always add a new public audio clip for new sound effects

    void Start(){
        musicSource.clip = cricket;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip){
        SFXSource.PlayOneShot(clip);
    }

}
