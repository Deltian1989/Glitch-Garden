using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
    }

    public void TurnOnMusic()
    {
        if (!audioSource.isPlaying)
            audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}
