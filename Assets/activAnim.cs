using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activAnim : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void animOn()
    {
       
        anim.Play("Panel_Menu_On");
    }

    public void animoff()
    {
        anim.Play("Panel_Menu_Off");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
