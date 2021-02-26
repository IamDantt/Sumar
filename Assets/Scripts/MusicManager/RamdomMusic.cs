using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamdomMusic : MonoBehaviour
{

    public AudioClip[] clips;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private AudioClip GetRamdomClip()
    {
        return clips[Random.Range(0, clips.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = GetRamdomClip();
            audioSource.Play();
        }
    }
}
