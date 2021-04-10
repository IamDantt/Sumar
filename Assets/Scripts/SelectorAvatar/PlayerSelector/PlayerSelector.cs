using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelector : MonoBehaviour
{

    public Animator animAvatar;

    public Image[] seleccion;

    public GameObject[] prefabs;

    public GameObject Panel;

    

    public int AvatarSelect, SeInstancio = 0;

    public Button Selector;
    

    void Start()
    {
        animAvatar = GetComponent<Animator>();

        this.select(0);

        Selector = GameObject.Find("Btn_Selector").GetComponent<Button>();


        AvatarSelect = PlayerPrefs.GetInt("Avatar", AvatarSelect);
        verificar();

        foreach (var img in this.seleccion)
        {
            img.gameObject.SetActive(false);
        } 

       this.select(AvatarSelect);

        SeInstancio = PlayerPrefs.GetInt("instanciado", SeInstancio);

    }
    

    void Update()
    {       
        
    }

    public void select(int index)
    {
        foreach (var img in this.seleccion)
        {
            img.gameObject.SetActive(false);
        } 

        this.seleccion[index].gameObject.SetActive(true);
        
        AvatarSelect = index;
        Debug.Log(AvatarSelect);

    }
    public void DesSelected()
    {
        
        AvatarSelect = 0;
        PlayerPrefs.SetInt("Avatar", AvatarSelect);
    }
    public void instanciar()
    {
        verificar();


        SeInstancio = 1;
        PlayerPrefs.SetInt("instanciado", SeInstancio);

        PlayerPrefs.SetInt("Avatar", AvatarSelect);
        

    }

    public void verificar()
    {
        if (AvatarSelect == 0)
        {
            prefabs[0].SetActive(true);
        }
        if (AvatarSelect == 1)
        {
            prefabs[1].SetActive(true);
        }
        if (AvatarSelect == 2)
        {
            prefabs[2].SetActive(true);
        }
        if (AvatarSelect == 3)
        {
            prefabs[3].SetActive(true);
        }
    }

    public void abrirPanel()
    {
        //Panel.SetActive(true);
        animAvatar.Play("AvatarSelecOn");
    }

    public void CerrarPanel()
    {
        //Panel.SetActive(false);
        animAvatar.Play("AvatarSelecOff");
    }

    

    

}
