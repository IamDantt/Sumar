using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.EventSystems;

public class PreguntasJson : MonoBehaviour
{
    

    

    public InputField inputFieldstudent;

    [Header("Paneles")]
    public GameObject Login; public GameObject Menu; public GameObject Pregunta;
    
    [Header("Menu botones")]
    public GameObject Btn_Volver; public GameObject Btn_Menu; public GameObject Aviso;
    public Color MyGreenColor, MyRedColor;




    void Start()
    {

        GetQuest();
    }

    public void GetQuest()
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
                StartCoroutine(Esperar());

            }
            else
            {
                processJsonData(www.downloadHandler.text);
                Login.SetActive(false);
                Menu.SetActive(true);

            }
        }

    }

    IEnumerator Esperar()
    {
        Aviso.SetActive(true);
        yield return new WaitForSeconds(3);
        Aviso.SetActive(false);

    }

    private void processJsonData(string _url)
    {
        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        GameObject g;


        jsonData jsnData = JsonUtility.FromJson<jsonData>(_url);

        

        foreach (ActividadesList x in jsnData.actividades)
        {

            g = Instantiate(buttonTemplate, transform);
           // g.transform.GetChild(0).GetComponent<Text>().text = x.nombre;


            for (int d = 0; d < x.nombre.Length; d++)
            {

                for (int j = 0; j < x.preguntas.Count; j++)
                {
                    
                    g.transform.GetChild(j+1).GetComponent<Text>().text = x.preguntas[j];

                }
            }                     

        }
        Destroy(buttonTemplate);
    }


    public void Volver()
    {
        Menu.SetActive(true);
        Btn_Menu.SetActive(true);
        Btn_Volver.SetActive(false);
    }
}
