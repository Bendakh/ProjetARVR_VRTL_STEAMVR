using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] ambianceClip;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayWaiting();
    }

    public void PlayAmbiance()
    {
        audioSource.clip = ambianceClip[0];
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
        audioSource.clip = null;
    }

    public void PlayWaiting()
    {
        audioSource.clip = ambianceClip[1];
        audioSource.Play();
    }

    public void FadeOut(float duration)
    {
       audioSource.GetComponent<MonoBehaviour>().StartCoroutine(FadeOutCore(audioSource, duration));
    }

    private IEnumerator FadeOutCore(AudioSource a, float duration)
    {
        float startVolume = a.volume;

        while (a.volume > 0)
        {
            a.volume -= startVolume * Time.deltaTime / duration;
            yield return new WaitForEndOfFrame();
        }

        a.Stop();
        a.volume = startVolume;
    }
}
