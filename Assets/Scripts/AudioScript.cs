using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{

    private AudioSource audioSource;

    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        Invoke("PlayAudio", delay);
    }

    private void PlayAudio()
    {
        audioSource.Play();
    }
}
