using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescativarBtn : MonoBehaviour
{

    public GameObject Button;
    // Start is called before the first frame update
    void Start()
    {
       

    }

    public void desactBtn()
    {
        if (EnviarBD.infoEnviada == true)
        {
            
        }
        Button.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
