using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class jsonController : MonoBehaviour
{
    //public string jsonURL;

    public Text nombre, pregunta, idper, puntuacin, calificacion, dispo;

    public InputField inputFieldstudent;

    //public Dropdown myDropdown;

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
                processJsonData(www.downloadHandler.text);
                //StartCoroutine(getTmg(www.downloadHandler.text));
                
            }
        }
        
    }

    /*IEnumerator getTmg(string _url)
    {
        Debug.Log(" esta es mi url " + _url);

        jsonData jsnData = JsonUtility.FromJson<jsonData>(_url);

        

        //WWW wwwLoader = new WWW(_url);
        

        foreach (ActividadesList x in jsnData.actividades)
        {

            for (int i = 0; i < x.img.Count; i++)
            {
                Debug.Log("URL" + x.img[i]);
                UnityWebRequest req = UnityWebRequestTexture.GetTexture(x.img[i]);
                yield return req.SendWebRequest();

                Texture2D img = ((DownloadHandlerTexture)req.downloadHandler).texture;
                image.sprite = Sprite.Create(img, new Rect(0, 0, img.width, img.height),Vector2.zero);

                //image.material.color = Color.white;
                //image.material.mainTexture = wwwLoader.texture;

            }

            
        }
    }*/

    private void processJsonData(string _url)
    {
        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        GameObject g;

       
        jsonData jsnData = JsonUtility.FromJson<jsonData>(_url);


       
        //myDropdown.options.Clear();
        idper.text = jsnData.id_persona.ToString();
        puntuacin.text =  jsnData.puntuacion.ToString();

        
       
        //Debug.Log("-------------------------------------");
        foreach (ActividadesList x in jsnData.actividades)
        {
           

            //Debug.Log("nombre actividad " + x.nombre);


            //cantVar = x.nombre.Length;
           // Debug.Log("Cantidad e nombres son: " + x.nombre.Length);
            g = Instantiate(buttonTemplate, transform);
            g.transform.GetChild(0).GetComponent<Text>().text = x.nombre;
            //g.transform.GetChild(4).GetComponent<Text>().text = "8D";

            switch (x.disponible)
            {
                case "1":
                    g.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = Color.green;
                    break;
                case "0":
                    g.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = Color.red;
                    break;
 
            }

            for (int d = 0; d < x.nombre.Length; d++)
            {
                
                //Debug.Log("nombre actividad " + x.nombre);
                


                //Debug.Log("------------------preguntas-------------------");
                for (int j = 0; j < x.preguntas.Count; j++)
                {
                    //myDropdown.options.Add(new Dropdown.OptionData(x.preguntas[j]));
                    var lol = j + 1;
                   // Debug.Log(x.preguntas[j]);

                    // pregunta.text = x.preguntas[j].ToString();
                    switch (x.respuestas[j])
                    {
                        case "1":
                            g.transform.GetChild(j+1).GetChild(0).GetComponent<Image>().color = Color.green;
                            break;
                        case "0":
                            g.transform.GetChild(j+1).GetChild(0).GetComponent<Image>().color = Color.red;
                            break;

                    }
                    g.transform.GetChild(j + 1).GetComponent<Text>().text = x.preguntas[j];

                }
                //Debug.Log("------------------respuestas-------------------");
                for (int i = 0; i < x.respuestas.Count; i++)
                {
                    var lol2 = i + 1;
                    //Debug.Log(x.respuestas[i]);
                }
                //Debug.Log("-------------------------------------");

              

            }

           // dispo.text ="disponibilidad " + x.disponible.ToString();
            //calificacion.text = "Calificacion " + x.calificacion.ToString();                      

        }
        Destroy(buttonTemplate);
    }

    
}
