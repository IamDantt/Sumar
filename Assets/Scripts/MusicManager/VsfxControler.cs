using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VsfxControler : MonoBehaviour
{
    public AudioSource BgMusic/*, SfxManager*/;

    public Slider _BgMusic/*, _SfxManager*/;

    //public GameObject GBgMusic;

    // Start is called before the first frame update
    void Start()
    {
        

        BgMusic = GetComponent<AudioSource>();

       _BgMusic.value = PlayerPrefs.GetFloat("SFxVolumen", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        BgMusic.volume = _BgMusic.value;
        //SfxManager.volume = _SfxManager.value;
    }

    public void GuardarVolumen()
    {
        PlayerPrefs.SetFloat("SFxVolumen", BgMusic.volume);
        //PlayerPrefs.SetFloat("SfxVolumen", SfxManager.volume);
    }
}
