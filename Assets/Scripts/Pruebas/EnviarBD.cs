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

    //public InputField inputFieldActivity;
    public InputField inputFieldstudent;

    public static bool infoEnviada = false;
    

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
        id_Pregunta = variable.id_pregunta;

    }

    
    public void Enviaradb()
    {
        StartCoroutine(EnviaralDB( id_Pregunta, inputFieldstudent.text, Respuesta));
    }


    IEnumerator EnviaralDB(string id_pregunta, string id_persona, string respuesta)
    {

        WWWForm form = new WWWForm();
        form.AddField("addPregunta", id_pregunta);
        form.AddField("addPersona", id_persona);
        form.AddField("addRespuesta", respuesta);

        using (UnityWebRequest www = UnityWebRequest.Post("https://campus.eduriot.com/php/EnviarDatosBD.php", form))
        {
            yield return www.Send();
            Debug.Log(www.downloadHandler.text);
            RegrePanel();
            StartCoroutine(OffAviso());
            infoEnviada = true;
        }
    }

    public void RegrePanel()
    {
        panelMenu.SetActive(true);
        panelOpc.SetActive(false);
        //SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Confirm);
    }

    IEnumerator OffAviso()
    {
        aviso_Text.SetActive(true);
        yield return new WaitForSeconds(2);
        aviso_Text.SetActive(false);
    }

}
