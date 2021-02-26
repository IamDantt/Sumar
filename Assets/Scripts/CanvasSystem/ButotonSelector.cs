using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButotonSelector : MonoBehaviour
{
    public GameObject[] contenedor;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        contenedor = new GameObject[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            contenedor[i] = transform.GetChild(i).gameObject;

        foreach (GameObject objx in contenedor)
            objx.SetActive(false);

        if (contenedor[index])
            contenedor[index].SetActive(true);
        
    }


    public void BtnLeft()
    {
        contenedor[index].SetActive(false);
        index--;
        if (index < 0)
            index = contenedor.Length - 1;
        contenedor[index].SetActive(true);
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Arrows);
    }
    public void BtnRight()
    {
        contenedor[index].SetActive(false);
        index++;
        if (index == contenedor.Length)
            index = 0;
        contenedor[index].SetActive(true);
        SfxManager.sfxInstance.Audio.PlayOneShot(SfxManager.sfxInstance.Arrows);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
