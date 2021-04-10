using System.Collections;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Networking;


public static class ButtonExtension
{
	public static void AddEventListener<T>(this Button button, T param, Action<T> OnClick)
    {
        button.onClick.AddListener(delegate(){
			OnClick(param);
        });
    }
}


public class LeerPhp : MonoBehaviour
{

	public InputField inputFieldActivity;
	public InputField inputFieldstudent;


	public GameObject panel2, panelMenu, panel, panel0, aviso;
	public Text pregunta, opc0, opc1, opc2, opc3, NameUser;

	public Button Btn_Enviar;

	[SerializeField] Text info;

	public string Respuesta;
	

	[System.Serializable]
	public struct Activity
	{
		public string pregunta;
		public string tipo_pregunta;
		public string respuesta;
		public string opciones;
	}

	public string[] _DivOpciones;

	public Activity[] allAtivity;

	void Start()
	{

		aviso.SetActive(false);
		

		panel2.SetActive(true);
		panel.SetActive(true);
		panel0.SetActive(true);

	}


	public void Entrar()
	{
		if (!string.IsNullOrEmpty(inputFieldstudent.text) && !string.IsNullOrEmpty(inputFieldActivity.text))
		{
			
			StartCoroutine(login(inputFieldstudent.text, inputFieldActivity.text));
			StartCoroutine(GetName(inputFieldstudent.text, inputFieldActivity.text));
			Btn_Enviar.interactable = false;


		}
		if (!string.IsNullOrEmpty(inputFieldActivity.text))
		{
			StartCoroutine(GetActivity(inputFieldActivity.text , inputFieldstudent.text));

		}
	}
	public void verifyInputs()
	{
		Btn_Enviar.interactable = (inputFieldstudent.text.Length >= 5 && inputFieldActivity.text.Length >= 3);
	}

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
				SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Alert);
				Debug.Log(www.error);
				info.text = "Error de acceso";
			}
			else
			{
				Debug.Log(www.downloadHandler.text);
				//NameUser.text = studentcode.ToString();

			}

		}
	}

	IEnumerator GetName(string studentcode, string activitycode)
	{
		WWWForm form = new WWWForm();
		form.AddField("code_estudiante", studentcode);
		form.AddField("code_actividad", activitycode);

		using (UnityWebRequest www = UnityWebRequest.Post("https://campus.eduriot.com/php/GetName.php", form))
		{
			yield return www.SendWebRequest();

			if (www.isNetworkError || www.isHttpError)
			{
				SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Alert);
				Debug.Log(www.error);
				info.text = "Error de al obtener nombre de usuario";
			}
			else
			{
				
				NameUser.text = www.downloadHandler.text.ToString();

			}

		}
	}

	IEnumerator GetActivity(string activitycode, string studentcode)
	{

		WWWForm form = new WWWForm();
		form.AddField("code_actividad", activitycode);
		form.AddField("code_estudiante", studentcode);



		string url = "https://campus.eduriot.com/php/pedir_datos.php";

		UnityWebRequest request = UnityWebRequest.Post(url, form);
		request.chunkedTransfer = false;
		yield return request.SendWebRequest();

		if (request.isNetworkError)
		{
			StartCoroutine(CloseAviso());
			info.text = "Error de coneccion";
			SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Alert);
		}
		else
		{
			if (request.isDone)
			{
				
				//Debug.Log(request.downloadHandler.text);
				allAtivity = JsonHelper.GetArray<Activity>(request.downloadHandler.text);
					
				StartCoroutine(CloseAviso());
					info.text = request.downloadHandler.text.ToString();
					DrawUI();
				panel2.SetActive(false);
				panelMenu.SetActive(true);
				panel0.SetActive(false);


			}
		}
	}

	IEnumerator CloseAviso()
    {

		aviso.SetActive(true);
		SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Alert);
		yield return new WaitForSeconds(2);
		aviso.SetActive(false);
	}


	void DrawUI()
	{
		GameObject buttonTemplate = transform.GetChild(0).gameObject;
		GameObject g;

		int N = allAtivity.Length;

		for (int i = 0; i < N; i++)
		{
			g = Instantiate(buttonTemplate, transform);

			g.transform.GetChild(1).GetComponent<Text>().text = allAtivity[i].pregunta;

			g.GetComponent<Button>().AddEventListener(i, ItemClicked);

		}

		Destroy(buttonTemplate);
	}

	void ItemClicked(int intemIndex)
	{
		

		panel2.SetActive(true);
		panelMenu.SetActive(false);
		

		pregunta.text = allAtivity[intemIndex].pregunta.ToString();
		_DivOpciones = allAtivity[intemIndex].opciones.Split('-');	
		

		for (int i = 0; i < _DivOpciones.Length; i++)
        {
			opc0.text = _DivOpciones[0].ToString();			
			opc1.text = _DivOpciones[1].ToString();
			opc2.text = _DivOpciones[2].ToString();
			opc3.text = _DivOpciones[3].ToString();
		}



	}

	public void GetUserName()
    {

    }
	
}
