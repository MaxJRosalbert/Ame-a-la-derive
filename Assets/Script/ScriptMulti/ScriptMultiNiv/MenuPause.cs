using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public GameObject[] objetAApparaitrePtPause;
    public GameObject[] objetADisparaitrePtPause;

    public GameObject[] objetAApparaitreGrPause;
    public GameObject[] objetADisparaitreGrPause;

    public GameObject[] objetAApparaitreOption;
    public GameObject[] objetADisparaitreOption;

    public GameObject[] objetAApparaitreChoix;
    public GameObject[] objetADisparaitreChoix;

    public GameObject[] objetAApparaitreQuitter;
    public GameObject[] objetADisparaitreQuitter;

    public GameObject[] objetADisparaitreOuiChoix;

    public GameObject[] objetADisparaitreNonChoix;

    public GameObject[] objetADisparaitreOuiQuitte;

    public GameObject[] objetADisparaitreNonQuitte;

    public GameObject Perso;


    public void InterfacePause()
    {
        foreach (GameObject Obj in objetADisparaitrePtPause)
        {
            Obj.SetActive(false);
        }

        foreach (GameObject Obj in objetAApparaitrePtPause)
        {
            Obj.SetActive(true);
        }

        //Chrono
    }
    public void FinPause()
    {
        foreach (GameObject Obj in objetADisparaitreGrPause)
        {
            Obj.SetActive(false);
        }

        foreach (GameObject Obj in objetAApparaitreGrPause)
        {
            Obj.SetActive(true);
        }

        //Chrono
    }
    public void Option()
    {
        foreach (GameObject Obj in objetADisparaitreOption)
        {
            Obj.SetActive(false);
        }

        foreach (GameObject Obj in objetAApparaitreOption)
        {
            Obj.SetActive(true);
        }
    }
    public void RetourChoixNiv()
    {
        foreach (GameObject Obj in objetADisparaitreChoix)
        {
            Obj.SetActive(false);
        }

        foreach (GameObject Obj in objetAApparaitreChoix)
        {
            Obj.SetActive(true);
        }
    }
    public void ChoixNivOui()
    {
        foreach (GameObject Obj in objetADisparaitreOuiChoix)
        {
            Obj.SetActive(false);
        }

        SceneManager.LoadScene("choix-Niv");
    }
    public void ChoixNivNon()
    {
        foreach (GameObject Obj in objetADisparaitreNonChoix)
        {
            Obj.SetActive(false);
        }

    }
    public void QuitterNiv()
    {
        foreach (GameObject Obj in objetADisparaitreQuitter)
        {
            Obj.SetActive(false);
        }

        foreach (GameObject Obj in objetAApparaitreQuitter)
        {
            Obj.SetActive(true);
        }
    }
    public void QuitterNivOui()
    {
        foreach (GameObject Obj in objetADisparaitreOuiQuitte)
        {
            Obj.SetActive(false);
        }

        SceneManager.LoadScene("Intro");
    }
    public void QuitterNivNon()
    {
        foreach (GameObject Obj in objetADisparaitreNonQuitte)
        {
            Obj.SetActive(false);
        }
    }

}
