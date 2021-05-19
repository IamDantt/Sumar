using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Networking;


/*public static class ButtonExtension
{
	public static void AddEventlistener<T>(this Button button, T param, Action<T> OnClick)
	{
		button.onClick.AddListener(delegate () {
			OnClick(param);
		});
	}
}*/

public class GetPhpData : MonoBehaviour
{

	
	public InputField inputFieldstudent;


	//public GameObject panel2, panelMenu, panel, panel0, aviso;
	//public Text pregunta, opc0, opc1, opc2, opc3, NameUser, ID_Pregunta;

	public Button Btn_Enviar;

	[SerializeField] Text info;

	//public string Respuesta;

	[System.Serializable]
	public class jsonData
	{
		public string id_persona;
		public string puntuacion;
		public List<ActividadesList> actividades;

	}

	[System.Serializable]
	public class ActividadesList
	{
		public string nombre;
		public string disponible;
		public string calificacion;
		public List<string> preguntas;
		public List<string> respuestas;
	}


	//public string[] _DivOpciones;
	[System.Serializable]
	public class AllActivitys
    {
		public jsonData[] Id;
		public ActividadesList[] Ativity;
	}

	public ActividadesList[] allAtivity;

	public AllActivitys MyId = new AllActivitys();



	void Start()
	{

	}


	public void Entrar()
	{
		if (!string.IsNullOrEmpty(inputFieldstudent.text))
		{

			StartCoroutine(login(inputFieldstudent.text));
			Btn_Enviar.interactable = false;


		}
	}
	public void verifyInputs()
	{
		Btn_Enviar.interactable = (inputFieldstudent.text.Length >= 5);
	}

	IEnumerator login(string studentcode)
	{
		WWWForm form = new WWWForm();
		form.AddField("code_estudiante", studentcode);

		using (UnityWebRequest www = UnityWebRequest.Post("https://campus.eduriot.com/php/enviar_actividades.php", form))
		{
			yield return www.SendWebRequest();

			if (www.isNetworkError || www.isHttpError)
			{
				SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Alert);
				Debug.Log(www.error);
				info.text = "Error de acceso";
			}
			else
			{
				jsonData jsnData = JsonUtility.FromJson<jsonData>("https://campus.eduriot.com/php/enviar_actividades.php");

				Debug.Log(www.downloadHandler.text);

				foreach (ActividadesList x in jsnData.actividades)
				{

					Debug.Log("Nombre Actividad " + x.nombre);
					Debug.Log("Disponibilidad " + x.disponible);
					Debug.Log("Calificación " + x.calificacion);

				}
				//DrawUI();
				//NameUser.text = studentcode.ToString();

			}

		}
	}


	void DrawUI()
	{
		GameObject buttonTemplate = transform.GetChild(0).gameObject;
		GameObject g;

		int N = allAtivity.Length;

		for (int i = 0; i < N; i++)
		{
			g = Instantiate(buttonTemplate, transform);

			g.transform.GetChild(1).GetComponent<Text>().text = allAtivity[i].nombre;
			//g.transform.GetChild(2).GetComponent<Text>().text = allAtivity[i].id_pregunta;
			
			//g.GetComponent<Button>().AddEventListener(i, ItemClicked);

		}

		Destroy(buttonTemplate);
	} 

	/*
	void ItemClicked(int intemIndex)
	{


		//panel2.SetActive(true);


		//ID_Pregunta.text = allAtivity[intemIndex].id_pregunta.ToString();
		//pregunta.text = allAtivity[intemIndex].pregunta.ToString();
		_DivOpciones = allAtivity[intemIndex].opciones.Split('-');


		for (int i = 0; i < _DivOpciones.Length; i++)
		{
			opc0.text = _DivOpciones[0].ToString();
			opc1.text = _DivOpciones[1].ToString();
			opc2.text = _DivOpciones[2].ToString();
			opc3.text = _DivOpciones[3].ToString();


		} */



	}

