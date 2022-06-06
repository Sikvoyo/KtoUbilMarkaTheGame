using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource audioSource;
    public bool playFootsteps = true;

    [SerializeField] AudioClip footsteps;

    private void Awake()
    {
        ProcessSingelton();

        audioSource = GetComponent<AudioSource>();
    }

    private void ProcessSingelton()
    {
        if (FindObjectsOfType<Music>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void StartMusic()
    {
        audioSource.Play();
    }

    public bool IsPlaying()
    {
        return audioSource.isPlaying;
    }

    public void PlayFootsteps()
    {   
        if (!playFootsteps) return;
        audioSource.PlayOneShot(footsteps);
    }
}
