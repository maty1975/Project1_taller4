using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonido_muerte : MonoBehaviour
{
    public AudioSource AudioSources;

    public AudioClip audio_explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void reproducir_explosion()
    {
        AudioSources.clip = audio_explosion;
        AudioSources.Play();
    }

    public void instanciar_explosion()
    {
        AudioSources.PlayOneShot(audio_explosion);
    }
}
