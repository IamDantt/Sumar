using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject StartP, PreQuest, MenuLeft, Welcome,Quest;
    void Start()
    {
        StartP.SetActive(true);
        PreQuest.SetActive(false);
        MenuLeft.SetActive(false);
        Welcome.SetActive(false);
        Quest.SetActive(false);
    }

  public void Entrar()
  {
        StartP.SetActive(false);
        PreQuest.SetActive(false);
        MenuLeft.SetActive(false);
        Welcome.SetActive(true);
        Quest.SetActive(false);
  }
  public void Continuar()
  {
        StartP.SetActive(false);
        PreQuest.SetActive(true);
        MenuLeft.SetActive(false);
        Welcome.SetActive(false);
        Quest.SetActive(false);
  }
  public void Responder()
  {
        StartP.SetActive(true);
        PreQuest.SetActive(false);
        MenuLeft.SetActive(false);
        Welcome.SetActive(false);
        Quest.SetActive(true);
  }
   public void Volver()
  {
        StartP.SetActive(true);
        PreQuest.SetActive(false);
        MenuLeft.SetActive(false);
        Welcome.SetActive(false);
        Quest.SetActive(false);
  }
    public void Menu()
  {
      
        MenuLeft.SetActive(true);
       
  }
   public void ExitMenu()
  {
      
        MenuLeft.SetActive(false);
       
  }
    
}
