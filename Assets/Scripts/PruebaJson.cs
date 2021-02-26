using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.Networking;


public class PruebaJson : MonoBehaviour
{
	// Este fue el script que use de prueba para instanciar estoy trabajando para unirlo con lo demas y empezar a dejar funcionando todo.

	public InputField inputFieldActivity;

	[System.Serializable]
	public struct Game
	{
		public string pregunta;	
		public string respuesta;
		public int tipo_pregunta;
		public string opciones;
	}
    
	 public Game[] allGames;


	void Start ()
	{
		StartCoroutine (GetGames (inputFieldActivity.text));

	}
	public void Entrara(){

	}

	void DrawUI ()
	{
		GameObject buttonTemplate = transform.GetChild(0).gameObject;
		GameObject g;

		int N = allGames.Length;

		for (int i = 0; i < N; i++) {
			g = Instantiate (buttonTemplate, transform);
									
			g.transform.GetChild (0).GetComponent <Text> ().text = allGames [i].pregunta;
			g.transform.GetChild(1).GetComponent<Text>().text = allGames[i].opciones;
			
		}

		

		Destroy (buttonTemplate);
	}

	//***************************************************
	IEnumerator GetGames (string activitycode)
	{
		WWWForm form = new WWWForm();
		form.AddField("code_actividad", activitycode);

		string url = "http://localhost/UnityTesis/GetActIDs.php";
        
		UnityWebRequest request = UnityWebRequest.Post (url, form);
		//UnityWebRequest request = UnityWebRequest.Get (url);
		//request.chunkedTransfer = false;
		yield return request.SendWebRequest();

		if (request.isNetworkError) {
			//show message "no internet "
		} else {
			if (request.isDone) {
				allGames = JsonHelper.GetArray<Game> (request.downloadHandler.text);
				Debug.Log(request.downloadHandler.text);
				DrawUI ();
	            
			}
		}
			
	}
}