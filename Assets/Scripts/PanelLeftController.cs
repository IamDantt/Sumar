using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelLeftController : MonoBehaviour
{
    
    public Animator panel_Anim;
    public Text VerApp;

    // Start is called before the first frame update
    void Start()
    {
        panel_Anim = GetComponent<Animator>();

        VerApp.text = "V" +" "+ Application.version.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Ocultar_Panel()
    {
        panel_Anim.Play("MenuLeftClose");
    }
    public void Mostrar_Panel()
    {
        panel_Anim.Play("MenuLeftOpen");
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    public void ReloadScene(int val)
    {
        SceneManager.LoadScene(val);
    }

    

}
