using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip deathSFX;
    private AudioSource _audioSourceSFX;
    public AudioClip goombaSFX;
    public AudioClip monedaSFX;
    public AudioClip banderaSFX;

    void Awake()
    {
        _audioSourceSFX = GetComponent<AudioSource>();
    }

    public void DeathSound()
    {
        _audioSourceSFX.PlayOneShot(deathSFX);
    }

    public void GoombaSound()
    {
         _audioSourceSFX.PlayOneShot(goombaSFX);
    }

    public void MonedaSound()
    {
        _audioSourceSFX.PlayOneShot(monedaSFX);
    }
    public void BanderaSound()
    {
        _audioSourceSFX.PlayOneShot(banderaSFX);
    }
}
