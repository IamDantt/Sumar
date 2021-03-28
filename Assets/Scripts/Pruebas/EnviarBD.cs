using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnviarBD : MonoBehaviour
{
    
    public string id_Pregunta, id_Persona, id_Actividad, Respuesta;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Enviaradb()
    {
        StartCoroutine(EnviaralDB( id_Pregunta, id_Persona, id_Actividad, Respuesta));
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
        }
    }

}
