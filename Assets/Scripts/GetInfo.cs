using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GetInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Nombre;

	public InputField inputFieldstudent;


	public void validar()
    {
		if (!string.IsNullOrEmpty(inputFieldstudent.text))
		{
			// StartCoroutine(GetRequest("http://localhost/UnityTesis/carga.php"));
			// StartCoroutine(GetRequest("https://error.html"));
			StartCoroutine(GetName(inputFieldstudent.text));


		}
	}

	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


	IEnumerator GetName(string studentcode)
	{
		WWWForm form = new WWWForm();
		form.AddField("code_estudiante", studentcode);

		string url = "http://localhost/UnityTesis/pedir_datos.php";

		UnityWebRequest request = UnityWebRequest.Post(url, form);
		//UnityWebRequest request = UnityWebRequest.Get (url);
		//request.chunkedTransfer = false;
		yield return request.SendWebRequest();

		if (request.isNetworkError)
		{
			//show message "no internet "
		}
		else
		{
			if (request.isDone)
			{
				
				Debug.Log("Este es mi nombre" + request.downloadHandler.text);

				Nombre.text = request.downloadHandler.text.ToString();


			}
		}

	}

}
