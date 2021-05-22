using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BorrarPruebaTexto : MonoBehaviour
{

    public GameObject boton;

    public void obtenertexto()
    {
        Debug.Log("texto del boton" + this.GetComponent<Text>().ToString());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
