using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{

    public AudioClip[] targetDestroyed;
    public AudioSource audioSource;
    public AudioClip failSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayRandomTargetDestroyed()
    {
        audioSource.clip = targetDestroyed[Random.Range(0, targetDestroyed.Length)];
        audioSource.Play();
    }

    public void PlayFailSound()
    {
        audioSource.clip = failSound;
        audioSource.Play();
    }
}
