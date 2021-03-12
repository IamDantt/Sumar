using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DivString : MonoBehaviour
{
    // Probar dividir string
    public string sentencia;

    public string[] palabras;

    private void Start()
    {
        palabras = sentencia.Split('_');
    }



}
