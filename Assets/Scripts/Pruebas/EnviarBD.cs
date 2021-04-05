using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class EnviarBD : MonoBehaviour
{
    public string Respuesta;
    public string id_Pregunta;
    public GameObject panelMenu, panelOpc, aviso_Text;

    public InputField inputFieldActivity;
    public InputField inputFieldstudent;

    

    //public GameObject uno, dos, tres, cuatro;

    // Start is called before the first frame update
    void Start()
    {

       

        


        aviso_Text.SetActive(false);        
    }

    // Update is called once per frame
    void Update()
    {
        ObtenerTexto variable = GetComponent<ObtenerTexto>();
        Respuesta = variable.Respuesta_E;
    }

    /*public void obtenerTexto1()
    {
        Debug.Log(uno.GetComponentInChildren<Text>().text.ToString());
        Respuesta = uno.GetComponentInChildren<Text>().text.ToString();

    }
    public void obtenerTexto2()
    {
        Debug.Log(dos.GetComponentInChildren<Text>().text.ToString());
        Respuesta = dos.GetComponentInChildren<Text>().text.ToString();
    }
    public void obtenerTexto3()
    {
        Debug.Log(tres.GetComponentInChildren<Text>().text.ToString());
        Respuesta = tres.GetComponentInChildren<Text>().text.ToString();
    }
    public void obtenerTexto4()
    {
        Debug.Log(cuatro.GetComponentInChildren<Text>().text.ToString());
        Respuesta = cuatro.GetComponentInChildren<Text>().text.ToString();
    } */

    public void Enviaradb()
    {
        StartCoroutine(EnviaralDB( id_Pregunta, inputFieldstudent.text, inputFieldActivity.text, Respuesta));
    }


    IEnumerator EnviaralDB(string id_pregunta, string id_persona, string id_actividad, string respuesta)
    {

        WWWForm form = new WWWForm();
        form.AddField("addPregunta", id_pregunta);
        form.AddField("addPersona", id_persona);
        form.AddField("addActividad", id_actividad);
        form.AddField("addRespuesta", respuesta);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityTesis/EnviarDatosBD.php", form))
        {
            yield return www.Send();
            Debug.Log(www.downloadHandler.text);
            panelMenu.SetActive(true);
            panelOpc.SetActive(false);
            StartCoroutine(OffAviso());
        }
    }

    IEnumerator OffAviso()
    {
        aviso_Text.SetActive(true);
        yield return new WaitForSeconds(2);
        aviso_Text.SetActive(false);
    }

}
