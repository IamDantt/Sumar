using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaculadoraManager : MonoBehaviour
{
    public Text TexResult;

    public float opc1, opc2, Resul;

    public InputField Inputopc1, Inputopc2;

    public Dropdown buton_Operaciones;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    public void HandleInpudData(int val)
    {

        opc1 = float.Parse(Inputopc1.text);
        opc2 = float.Parse(Inputopc2.text);


        if (val == 0)
        {
            Resul = opc1 + opc2;
            TexResult.text = Resul.ToString();
        }
        if (val == 1)
        {
            Resul = opc1 - opc2;
            TexResult.text = Resul.ToString();
        }
        if (val == 2)
        {
            Resul = opc1 * opc2;
            TexResult.text = Resul.ToString();
        }
        if (val == 3)
        {
            Resul = opc1 / opc2;
            TexResult.text = Resul.ToString();
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
