using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void playMusic()
    {
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Play);
    }
    public void PlayWarning()
    {
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Warning);
    }
}
