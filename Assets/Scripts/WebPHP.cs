using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class WebPHP : MonoBehaviour
{
    public GameObject StartPant, Welcome;
    public InputField inputFieldstudent;
    public InputField inputFieldActivity;

    public Text Nombre;

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
            

        }  
          if(!string.IsNullOrEmpty(inputFieldActivity.text))
         {
              StartCoroutine(GetActID(inputFieldActivity.text));
              
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


    // Courotine Login

    IEnumerator login(string studentcode, string activitycode)
    {
        WWWForm form = new WWWForm();
        form.AddField("code_estudiante", studentcode);
        form.AddField("code_actividad", activitycode);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityTesis/pedir_datos.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                Debug.Log("Error Login");
            }
            else
            {
                //Panel de inicio
               
                Welcome.SetActive(true);
                StartPant.SetActive(false);
                Debug.Log("Login Succes");
                Debug.Log(www.downloadHandler.text);
                Nombre.text = www.downloadHandler.text.ToString();
                //DrawUI();

            }
            
        }
    }

    /*
    void DrawUI()
    {
        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        GameObject g;

        int N = allGames.Length;

        for (int i = 0; i < N; i++)
        {
            g = Instantiate(buttonTemplate, transform);

            g.transform.GetChild(0).GetComponent<Text>().text = allGames[i].pregunta;
            g.transform.GetChild(1).GetComponent<Text>().text = allGames[i].opciones;

        }
        Destroy(buttonTemplate);
    }
    */
    IEnumerator GetActID(string activitycode)
    {
        WWWForm form = new WWWForm();
        form.AddField("code_actividad", activitycode);

        using (UnityWebRequest request = UnityWebRequest.Post("http://localhost/UnityTesis/pedir_datos.php", form))
        {
            yield return request.SendWebRequest();

            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
              /*  WWW myWWW = new WWW(Application.dataPath + "http://localhost/UnityTesis/pedir_datos.php");   // UTF-8 encoded json file on the server
                yield return myWWW;
                string jsonData = "";
                if (string.IsNullOrEmpty(myWWW.error))
                {
                    jsonData = System.Text.Encoding.UTF8.GetString(myWWW.bytes, 3, myWWW.bytes.Length - 3);  // Skip thr first 3 bytes (i.e. the UTF8 BOM)
                    JSONObject json = new JSONObject(jsonData);   // JSONObject works now
                } */

                Debug.Log(request.downloadHandler.text);
            }
        }
    }
}
