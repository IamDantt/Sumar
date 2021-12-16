using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PreguntasManager : MonoBehaviour
{
    public InputField inputFieldstudent;
    // Start is called before the first frame update

    private void Start()
    {
        Entrar();
    }

    public void Entrar()
    {
        if (!string.IsNullOrEmpty(inputFieldstudent.text))
        {

            StartCoroutine(getData(inputFieldstudent.text));
            
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

    private void processJsonData(string _url)
    {
        jsonData jsnData = JsonUtility.FromJson<jsonData>(_url);

        GameObject buttonTemplate2 = transform.GetChild(0).gameObject;
        GameObject B;

        

        foreach (ActividadesList x in jsnData.actividades)
        {
            for (int j = 0; j < x.preguntas.Count; j++)
            {
                B = Instantiate(buttonTemplate2, transform);
            }
            Destroy(buttonTemplate2);
        }
    }

}
