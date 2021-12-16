using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;

public static class ButtonExtension3
{
    public static void AddEvenListener<T> (this Button button, T param, Action<T> Onclick)
    {
        button.onClick.AddListener(delegate ()
        {
            Onclick(param);
        });
    }
}

public class BotonDinamico : MonoBehaviour
{
    public InputField inputFieldstudent;
    public GameObject PanelLogin, PanelAR, PanelMenu, BtnVolver;
    public int ContActi = 0;
    public Color MyGreenColor, MyRedColor;
    public Text Nick;

    void Start()
    {
        Entrar();

        /* GameObject buttonTemplate = transform.GetChild(0).gameObject;
         GameObject g;
         for (int i = 0; i < 5; i++)
         {
             g = Instantiate(buttonTemplate, transform);
         }
         Destroy(buttonTemplate);*/ //para crear los botones
    }

    private void Update()
    {
        
    }

    public void Entrar()
    {
        if (!string.IsNullOrEmpty(inputFieldstudent.text))
        {

            StartCoroutine(getData(inputFieldstudent.text));
            PanelLogin.SetActive(false);
            PanelMenu.SetActive(true);

        }
    }

    IEnumerator getData(string studentcode)
    {




        WWWForm _www = new WWWForm();

        _www.AddField("code_estudiante", studentcode);

        //https://campus.eduriot.com/php/enviar_datos.php
        //using (UnityWebRequest www = UnityWebRequest.Post("https://campus.eduriot.com/php/enviar_actividades.php", _www)) Copia de seguridad de link xD

        using (UnityWebRequest www = UnityWebRequest.Post("https://campus.eduriot.com/php/enviar_datos.php", _www))
        {

            yield return www.SendWebRequest();

            if ((www.isNetworkError == null || www.isHttpError))
            {
                Debug.Log("El error es" + www.isNetworkError);
            }
            else
            {
                processJsonData(www.downloadHandler.text);
                
            }
        }

    }

    // Start is called before the first frame update
    

    private void processJsonData(string _url)
    {
        jsonData jsnData = JsonUtility.FromJson<jsonData>(_url);

        Nick.text = "Hola! "+ jsnData.nombre.ToString() + " " + jsnData.apellido.ToString();

        Debug.Log(_url);
        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        GameObject g;


        //Debug.Log(jsnData.descripcion);

        foreach (ActividadesList x in jsnData.actividades)
        {
            //Debug.Log("Estas son las oipcioens" + x.opciones);

            ContActi =+ 1;

            

            g = Instantiate(buttonTemplate, transform);
            g.transform.GetChild(1).GetComponent<Text>().text = x.nombre.ToString();
            g.transform.GetChild(2).GetComponent<Text>().text = jsnData.descripcion.ToString();
            //g.transform.GetChild(5).GetComponent<Text>().text = x.preguntas[1];

            
            for (int j = 0; j < x.preguntas.Count; j++)
            {
                g.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = x.preguntas[j];

                /*g = Instantiate(buttonTemplate, transform);
                g.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = x.preguntas[1]; 
               
                g.transform.GetChild(4).GetChild(0).GetChild(0).GetComponent<Text>().text = x.preguntas[1];
                */
            }

            /* for (int j = 0; j < x.opciones.Count; j++)
            {                
                Debug.Log("Estas son las opciones " + x.opciones.ToString());
            }
            */
            for (int i = 0; i < ContActi; i++)
            {
                g.GetComponent<Button>().AddEvenListener(i, ItenClicked);
            }
            

            //_______________________________Disponibilidad__________________________________//
            switch (x.disponibilidad)
            {
                case "1":
                    g.transform.GetChild(3).GetComponent<Image>().color = MyGreenColor;
                    break;
                case "0":
                    g.transform.GetChild(3).GetComponent<Image>().color = MyRedColor;
                    break;

            }
            //________________________________________________________________________________//

           /* for (int i = 0; i < ContActi; i++)
            {
                g.GetComponent<Button>().AddEvenListener(i, ItenClicked);
            }*/
            

            for (int i = 0; i < x.preguntas.Count; i++)
            {
                //Debug.Log("Pregunta " + x.preguntas[i]);
            }
            for (int i = 0; i < x.respuestas.Count; i++)
            {
                //Debug.Log("Respuestas " + x.respuestas[i]);
            }
           
        }
        Destroy(buttonTemplate);

    }

    void ItenClicked(int itenIndex)
    {
        Debug.Log("Item: " + itenIndex);
        PanelMenu.SetActive(false);
        BtnVolver.SetActive(true);
    }

    public void IrAr()
    {
        PanelAR.SetActive(true);
        PanelLogin.SetActive(false);
        PanelMenu.SetActive(false);
    }
    
    public void Iniciar()
    {
        //recargar escena
        SceneManager.LoadScene(0);
    }
    public void actMenu()
    {
        PanelMenu.SetActive(true);
    }
        // Update is called once per frame
   
}
