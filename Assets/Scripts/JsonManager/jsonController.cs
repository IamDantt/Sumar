using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.EventSystems;


public class jsonController : MonoBehaviour
{
    //public string jsonURL;

    public Text nombre, idper, puntuacin /*TextoPregunta ,pregunta, calificacion, dispo*/;

    public InputField inputFieldstudent;

    [Header("Paneles")]
    public GameObject Login; public GameObject Menu; public GameObject Pregunta;
    //public Dropdown myDropdown;
    [Header("Menu botones")]
    public GameObject Btn_Volver; public GameObject Btn_Menu;
    public Color MyGreenColor, MyRedColor;

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
                Login.SetActive(false);
                Menu.SetActive(true);
                
            }
        }
        
    }


    private void processJsonData(string _url)
    {
        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        GameObject g;

       
        jsonData jsnData = JsonUtility.FromJson<jsonData>(_url);

        idper.text = jsnData.id_persona.ToString();
        puntuacin.text =  jsnData.puntuacion.ToString();

        foreach (ActividadesList x in jsnData.actividades)
        {
           
            g = Instantiate(buttonTemplate, transform);
            g.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = x.nombre;

            
            //g.transform.GetChild(4).GetComponent<Text>().text = "8D";

            switch (x.disponible)
            {
                case "1":
                    g.transform.GetChild(0).GetComponent<Image>().color = MyGreenColor;
                    break;
                case "0":
                    g.transform.GetChild(0).GetComponent<Image>().color = MyRedColor;
                    break;
 
            }
            
            for (int d = 0; d < x.nombre.Length; d++)
            {
                
                for (int j = 0; j < x.preguntas.Count; j++)
                {
                   
                    var lol = j + 1;

                    switch (x.respuestas[j])
                    {
                        case "1":
                            g.transform.GetChild(j+1).GetChild(0).GetComponent<Image>().color = MyGreenColor;
                            break;
                        case "0":
                            g.transform.GetChild(j+1).GetChild(0).GetComponent<Image>().color = MyRedColor;
                            break;

                    }

                    g.transform.GetChild(j + 1).GetComponent<Text>().text = x.preguntas[j];

                    
                    //TextoPregunta.text = x.preguntas[j];
                    //g.GetComponent<Button>().onClick.AddEventListener(ItemClicked);


                }
                for (int i = 0; i < x.respuestas.Count; i++)
                {
                    var lol2 = i + 1;
                }

              

            }

           // dispo.text ="disponibilidad " + x.disponible.ToString();
            //calificacion.text = "Calificacion " + x.calificacion.ToString();                      

        }
        Destroy(buttonTemplate);
    }
    
    public void ItemClicked()
    {

        Debug.Log("el nombre es" + EventSystem.current.currentSelectedGameObject.name);

        //Debug.Log("Presionado");

        Pregunta.SetActive(true);
        Menu.SetActive(false);
        Btn_Menu.SetActive(false);
        Btn_Volver.SetActive(true);
    }

    public void Volver()
    {
        Menu.SetActive(true);
        Btn_Menu.SetActive(true);
        Btn_Volver.SetActive(false);
    }
}
