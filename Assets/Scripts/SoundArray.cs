using UnityEngine;
using System.Collections;

public class SoundArray : MonoBehaviour {

    public AudioClip[] randomSounds;
    public AudioSource m_audioSource;


    void PlayNextSound()
    {
        m_audioSource.clip = randomSounds[Random.Range(0, randomSounds.Length)];
        m_audioSource.Play();
        Invoke("PlayNextSound", m_audioSource.clip.length);
    }

    // Use this for initialization
    void Start () {
        PlayNextSound();
    }

    // Update is called once per frame
    void Update () {
       
      
    }
}
