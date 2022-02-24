using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    // Start is called before the first frame update

    private AudioSource _audioSource;

    void Awake ()
    {
        _audioSource =GetComponent<AudioSource>();

    }

    void Start()
    {
        _audioSource.Play();
    }

    public void StopBGM()
    {
        _audioSource.Stop();
    }

   
}
