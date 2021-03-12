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

	public GameObject panel2, panel;
	public Text pregunta, opc0, opc1, opc2, opc3;

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
		panel2.SetActive(false);
		panel.SetActive(true);
		StartCoroutine(GetActivity());

		

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

	IEnumerator GetActivity()
	{
		string url = "http://localhost/UnityTesis/pedir_datos.php";

		UnityWebRequest request = UnityWebRequest.Get(url);
		request.chunkedTransfer = false;
		yield return request.SendWebRequest();

		if (request.isNetworkError)
		{
			//show message "no internet "
		}
		else
		{
			if (request.isDone)
			{
				allAtivity = JsonHelper.GetArray<Activity>(request.downloadHandler.text);
				Debug.Log(request.downloadHandler.text);
				DrawUI();

			}
		}
	}

	void ItemClicked(int intemIndex)
	{
		panel2.SetActive(true);
		panel.SetActive(false);

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

	public void DivOpciones()
    {
		
    }
}
