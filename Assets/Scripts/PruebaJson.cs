using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.Networking;


public class PruebaJson : MonoBehaviour
{
	// Este fue el script que use de prueba para instanciar estoy trabajando para unirlo con lo demas y empezar a dejar funcionando todo.

	public InputField inputFieldActivity;
	public InputField inputFieldstudent;



	[System.Serializable]
	public struct Game
	{
		public string pregunta;
		public string tipo_pregunta;
		public string respuesta;		
		public string opciones;
	}
    
	 public Game[] allGames;


	void Start ()
	{
		StartCoroutine(GetGames(inputFieldActivity.text, inputFieldstudent.text));

	}
	public void Entrara()
	{
		
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
	IEnumerator GetGames (string studentcode, string activitycode)
	{
		WWWForm form = new WWWForm();
		form.AddField("code_actividad", activitycode);
		form.AddField("code_estudiante", studentcode);

		using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/UnityTesis/pedir_datos.php",form)){
			yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
				Debug.Log("error");
            }
            else
            {
				Debug.Log("detalles" + www.downloadHandler.text);
				string jsonArray = www.downloadHandler.text;
				DrawUI();
			}
        }



		/*
		string url = "http://localhost/UnityTesis/pedir_datos.php";
        
		UnityWebRequest request = UnityWebRequest.Post (url, form);
		//UnityWebRequest request = UnityWebRequest.Get (url);
		request.chunkedTransfer = false;
		yield return request.SendWebRequest();

		if (request.isNetworkError) {
			//show message "no internet "
		} else {
			if (request.isDone) {
				//StartCoroutine(jsontest());
				allGames = JsonHelper.GetArray<Game> (request.downloadHandler.text);
				Debug.Log(request.downloadHandler.text);
				DrawUI ();
	            
			}
		}
			*/
	}



	/*
	IEnumerator jsontest()
    {
		WWW myWWW = new WWW(Application.dataPath + "http://localhost/UnityTesis/pedir_datos.php");   // UTF-8 encoded json file on the server
		yield return myWWW;
		string jsonData = "";
		if (string.IsNullOrEmpty(myWWW.error))
		{
			jsonData = System.Text.Encoding.UTF8.GetString(myWWW.bytes, 3, myWWW.bytes.Length - 3);  // Skip thr first 3 bytes (i.e. the UTF8 BOM)
			JSONObject json = new JSONObject(jsonData);   // JSONObject works now
		}
	} */

}