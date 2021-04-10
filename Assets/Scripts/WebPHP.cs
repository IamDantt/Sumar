using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class WebPHP : MonoBehaviour
{
    //public GameObject StartPant, Welcome;
    public InputField inputFieldstudent;
    public InputField inputFieldActivity;

   

    //public Text Nombre;

    /*
    [System.Serializable]
    public struct Game
    {
        public string pregunta;
        public string tipo_pregunta;
        public string respuesta;
        public string opciones;
    }

    public Game[] allGames;

    */
    void Start()
    {
        

    }
 
    public void Entrar()
    {
        if(!string.IsNullOrEmpty(inputFieldstudent.text ))
         {
            // StartCoroutine(GetRequest("http://localhost/UnityTesis/carga.php"));
            // StartCoroutine(GetRequest("https://error.html"));
            StartCoroutine(login(inputFieldstudent.text,inputFieldActivity.text));
            SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Confirm);


        }  
          if(!string.IsNullOrEmpty(inputFieldActivity.text))
         {
              StartCoroutine(GetActID(inputFieldActivity.text));
              
        }    
    }

   
    

    // Courotine Login

    IEnumerator login(string studentcode, string activitycode)
    {
        WWWForm form = new WWWForm();
        form.AddField("code_estudiante", studentcode);
        form.AddField("code_actividad", activitycode);

        using (UnityWebRequest www = UnityWebRequest.Post("https://campus.eduriot.com/php/pedir_datos.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                Debug.Log("Error Login");
            }
            else
            {
                
                //Debug.Log("Login Succes");
                //Debug.Log(www.downloadHandler.text);
               

            }
            
        }
    }

    IEnumerator GetActID(string activitycode)
    {
        WWWForm form = new WWWForm();
        form.AddField("code_actividad", activitycode);

        using (UnityWebRequest request = UnityWebRequest.Post("https://campus.eduriot.com/php/pedir_datos.php", form))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
            }
        }
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
            }
        }
    }
}
