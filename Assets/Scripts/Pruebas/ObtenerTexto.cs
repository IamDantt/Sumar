﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObtenerTexto : MonoBehaviour
{
    public string Respuesta_E;
    public GameObject uno, dos, tres, cuatro, panel_COnfirmar;
    // Start is called before the first frame update
    void Start()
    {
        panel_COnfirmar.SetActive(false);
    }
    public void obtenerTexto1()
    {
        Debug.Log(uno.GetComponentInChildren<Text>().text.ToString());
        Respuesta_E = uno.GetComponentInChildren<Text>().text.ToString();
        panel_COnfirmar.SetActive(true);

    }
    public void obtenerTexto2()
    {
        Debug.Log(dos.GetComponentInChildren<Text>().text.ToString());
        Respuesta_E = dos.GetComponentInChildren<Text>().text.ToString();
        panel_COnfirmar.SetActive(true);
    }
    public void obtenerTexto3()
    {
        Debug.Log(tres.GetComponentInChildren<Text>().text.ToString());
        Respuesta_E = tres.GetComponentInChildren<Text>().text.ToString();
        panel_COnfirmar.SetActive(true);
    }
    public void obtenerTexto4()
    {
        Debug.Log(cuatro.GetComponentInChildren<Text>().text.ToString());
        Respuesta_E = cuatro.GetComponentInChildren<Text>().text.ToString();
        panel_COnfirmar.SetActive(true);
    }

    public void panel_Confirmar()
    {
        panel_COnfirmar.SetActive(false);
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Confirm);
    }

    public void OcultarPanel()
    {
        panel_COnfirmar.SetActive(false);
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Confirm);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
