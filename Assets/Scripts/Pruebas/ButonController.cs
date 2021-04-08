using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButonController : MonoBehaviour
{
    public Button[] Botones;
    public GameObject Guia;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ActiveButon()
    {
        Guia.SetActive(false);
        for (int i = 0; i < Botones.Length; i++)
        {
            Botones[i].interactable = true;
        }
        
    }
    public void DesctiveButon()
    {
        Guia.SetActive(true);
        for (int i = 0; i < Botones.Length; i++)
        {
            Botones[i].interactable = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
