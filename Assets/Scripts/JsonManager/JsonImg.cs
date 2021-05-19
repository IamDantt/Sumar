using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class JsonImg : MonoBehaviour
{
    //public string jsonURL;   

    public InputField inputFieldstudent;

    //public Image image;

    //public int cantVar;



    void Start()
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

        using (UnityWebRequest www = UnityWebRequest.Post("https://campus.eduriot.com/php/enviar_actividades.php", _www))
        {

            yield return www.SendWebRequest();

            if ((www.isNetworkError == null))
            {


            }
            else
            {

                //StartCoroutine(getTmg(www.downloadHandler.text));
                getTmg(www.downloadHandler.text);
            }
        }

    }

    private void getTmg(string _url)
    {
        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        GameObject g;

        jsonData jsnData = JsonUtility.FromJson<jsonData>(_url);

        foreach (ActividadesList x in jsnData.actividades)
        {

            g = Instantiate(buttonTemplate, transform);

            for (int i = 0; i < x.nombre.Length; i++)
            {
                for (int j = 0; j < x.img.Count; j++)
                {
                    //Debug.Log("URL" + x.img[j]);
                    UnityWebRequest req = UnityWebRequestTexture.GetTexture(x.img[j]);
                    return;

                    // Texture2D img = ((DownloadHandlerTexture)req.downloadHandler).texture;
                    // image.sprite = Sprite.Create(img, new Rect(0, 0, img.width, img.height), Vector2.zero);

                    //g.transform.GetChild(0).GetComponent<Image>().sprite = image.sprite;
                    g.transform.GetChild(0).GetComponent<Text>().text = x.img[i];


                }
                //Debug.Log("URL" + x.img[i]);
            }





        }
        Destroy(buttonTemplate);

    }
    /*IEnumerator getTmg(string _url)
    {
        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        GameObject g;

        jsonData jsnData = JsonUtility.FromJson<jsonData>(_url);
                    
        foreach (ActividadesList x in jsnData.actividades)
        {
            
            g = Instantiate(buttonTemplate, transform);

            for (int i = 0; i < x.nombre.Length; i++)
            {
                for (int j = 0; j < x.img.Count; j++)
                {
                    //Debug.Log("URL" + x.img[j]);
                    UnityWebRequest req = UnityWebRequestTexture.GetTexture(x.img[j]);
                    yield return req.SendWebRequest();

                    // Texture2D img = ((DownloadHandlerTexture)req.downloadHandler).texture;
                    // image.sprite = Sprite.Create(img, new Rect(0, 0, img.width, img.height), Vector2.zero);

                    //g.transform.GetChild(0).GetComponent<Image>().sprite = image.sprite;
                    g.transform.GetChild(0).GetComponent<Text>().text = x.img[i];


                }
                //Debug.Log("URL" + x.img[i]);
            }
            




        }
        Destroy(buttonTemplate);
        
    }*/


}
