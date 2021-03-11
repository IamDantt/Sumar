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

	public GameObject panel2,panel;
	public Text pregunta, opciones;

	[System.Serializable]
	public struct Activity
	{
		public string pregunta;
		public string tipo_pregunta;
		public string respuesta;
		public string opciones;
	}

	public Activity[] allAtivity;

    void Start ()
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

			g.GetComponent<Button> ().AddEventListener(i, ItemClicked);

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
		opciones.text = allAtivity[intemIndex].opciones.ToString();
	}

}
