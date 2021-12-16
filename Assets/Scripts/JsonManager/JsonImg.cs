using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class JsonImg : MonoBehaviour
{
    //public string jsonURL;   

    public InputField inputFieldstudent;

    public Image image;
    public GameObject Aviso;

    //public int cantVar;



    void Start()
    {

        //Entrar();
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

        using (UnityWebRequest www = UnityWebRequest.Post("https://campus.eduriot.com/php/enviar_datos_app.php", _www))
        {

            yield return www.SendWebRequest();

            if ((www.isNetworkError == null || www.isHttpError))
            {
                Aviso.SetActive(true);
                StartCoroutine(Esperar());

            }
            else
            {

                StartCoroutine(getTmg(www.downloadHandler.text));
            }
        }

    }

    IEnumerator Esperar()
    {
        Aviso.SetActive(true);
        yield return new WaitForSeconds(3);
        Aviso.SetActive(false);

    }


    IEnumerator getTmg(string _url)
     {

        jsonData jsnData = JsonUtility.FromJson<jsonData>(_url);

        //GameObject buttonTemplate = transform.GetChild(0).gameObject;
         //GameObject g;


        //Debug.Log(_url);
        
        foreach (ActividadesList x in jsnData.actividades)
        {
             Debug.Log("Nombre " + x.nombre);
           


            for (int i = 0; i < x.url_img.Count; i++)
            {
                Debug.Log("url" + x.url_img.Count);
                //g = Instantiate(buttonTemplate, transform);
                //for (int j = 0; j < x.img.Count; j++)
                //{


                // GameObject InObject = new GameObject();
                // Image image = InObject.AddComponent<Image>();


                
                     
                     UnityWebRequest req = UnityWebRequestTexture.GetTexture(x.url_img[i]);                    
                     yield return req.SendWebRequest();

                     if (req.isNetworkError || req.isHttpError)
                     {
                         Debug.Log(req.error);
                     }
                     else
                     {
                         Texture2D img = ((DownloadHandlerTexture)req.downloadHandler).texture;
                         image.sprite = Sprite.Create(img, new Rect(0, 0, img.width, img.height), Vector2.zero);
                         image.transform.GetComponent<Image>().sprite = image.sprite;
                         //g.transform.GetChild(0).GetComponent<Image>().sprite = image.sprite;
                     }



                // }

                //Debug.Log("URL" + x.img[i]);
                
            }
            

        }

       // Destroy(buttonTemplate);
    } 


}
