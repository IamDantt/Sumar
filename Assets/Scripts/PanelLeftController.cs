using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelLeftController : MonoBehaviour
{
    
    public Animator panel_Anim;
    public Text VerApp;
    public GameObject PanelAprender;
    // Start is called before the first frame update
    void Start()
    {
        PanelAprender.SetActive(false);
        panel_Anim = GetComponent<Animator>();

        VerApp.text = "V" +" "+ Application.version.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AprenderOn()
    {
        PanelAprender.SetActive(true);
    }
    public void AprenderOff()
    {
        PanelAprender.SetActive(false);
    }

    public void Ocultar_Panel()
    {
        panel_Anim.Play("MenuLeftClose");
        //SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Confirm);
    }
    public void Mostrar_Panel()
    {
        panel_Anim.Play("MenuLeftOpen");
        //SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Confirm);
    }
    public void OculPanelAprender()
    {
        PanelAprender.SetActive(false);
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void ReloadScene(int val)
    {
        SceneManager.LoadScene(val);
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Confirm);
    }

    

}
