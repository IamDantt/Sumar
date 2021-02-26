using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumenController : MonoBehaviour
{

    public AudioSource BgMusic/*, SfxManager*/;

    public Slider _BgMusic/*, _SfxManager*/;

    // Start is called before the first frame update
    void Start()
    {
        BgMusic = GetComponent<AudioSource>();
        //SfxManager = GetComponent<AudioSource>();
        //_BgMusic = GameObject.Find("BgSlider").GetComponent<Slider>();

        _BgMusic.value = PlayerPrefs.GetFloat("BgVolumen", 0.5f);
        //_SfxManager.value = PlayerPrefs.GetFloat("SfxVolumen", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        BgMusic.volume = _BgMusic.value;
        //SfxManager.volume = _SfxManager.value;
    }

    public void GuardarVolumen()
    {
        PlayerPrefs.SetFloat("BgVolumen", BgMusic.volume);
        //PlayerPrefs.SetFloat("SfxVolumen", SfxManager.volume);
    }

}
