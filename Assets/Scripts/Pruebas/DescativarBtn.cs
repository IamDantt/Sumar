using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescativarBtn : MonoBehaviour
{
    public GameObject btn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void desactBtn()
    {
        btn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
