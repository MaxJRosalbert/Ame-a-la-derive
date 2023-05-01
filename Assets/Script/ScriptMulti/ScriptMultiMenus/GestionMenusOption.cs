using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionMenusOption : MonoBehaviour
{
    public GameObject[] objetADisparaitreReglage;
    public GameObject[] objetAApparaitreReglage;

    public GameObject[] objetADisparaitreControle;
    public GameObject[] objetAApparaitreControle;

    public GameObject[] objetADisparaitreHistoire;
    public GameObject[] objetAApparaitreHistoire;

    public GameObject[] objetAApparaitreNiv1;
    public GameObject[] objetADisparaitreNiv1;

    public GameObject[] objetAApparaitreNiv2;
    public GameObject[] objetADisparaitreNiv2;

    public GameObject[] objetAApparaitreNiv3;
    public GameObject[] objetADisparaitreNiv3;

    public GameObject[] objetAApparaitreNiv4;
    public GameObject[] objetADisparaitreNiv4;

    public GameObject[] objetAApparaitreNiv5;
    public GameObject[] objetADisparaitreNiv5;

    public GameObject[] objetADisparaitreRetour;
    public GameObject[] objetAApparaitreRetour;

    public GameObject[] objetAApparaitreRetourHistoire;
    public GameObject[] objetADisparaitreRetourHistoire;

    public void Reglage()
    {
        foreach (GameObject Obj in objetADisparaitreReglage)
        {
            Obj.SetActive(false);
        }

        foreach (GameObject Obj in objetAApparaitreReglage)
        {
            Obj.SetActive(true);
        }
    }

    public void Controle()
    {
        foreach (GameObject Obj in objetADisparaitreControle)
        {
            Obj.SetActive(false);
        }

        foreach (GameObject Obj in objetAApparaitreControle)
        {
            Obj.SetActive(true);
        }
    }

    public void Histoire()
    {
        foreach (GameObject Obj in objetADisparaitreHistoire)
        {
            Obj.SetActive(false);
        }

        foreach (GameObject Obj in objetAApparaitreHistoire)
        {
            Obj.SetActive(true);
        }
    }


    public void Niv1()
    {
        foreach (GameObject Obj in objetAApparaitreNiv1)
        {
            Obj.SetActive(true);
        }

        foreach (GameObject Obj in objetADisparaitreNiv1)
        {
            Obj.SetActive(false);
        }
    }

    public void Niv2()
    {
        foreach (GameObject Obj in objetAApparaitreNiv2)
        {
            Obj.SetActive(true);
        }

        foreach (GameObject Obj in objetADisparaitreNiv2)
        {
            Obj.SetActive(false);
        }
    }

    public void Niv3()
    {
        foreach (GameObject Obj in objetAApparaitreNiv3)
        {
            Obj.SetActive(true);
        }

        foreach (GameObject Obj in objetADisparaitreNiv3)
        {
            Obj.SetActive(false);
        }
    }

    public void Niv4()
    {
        foreach (GameObject Obj in objetAApparaitreNiv4)
        {
            Obj.SetActive(true);
        }

        foreach (GameObject Obj in objetADisparaitreNiv4)
        {
            Obj.SetActive(false);
        }
    }

    public void Niv5()
    {
        foreach (GameObject Obj in objetAApparaitreNiv5)
        {
            Obj.SetActive(true);
        }

        foreach (GameObject Obj in objetADisparaitreNiv5)
        {
            Obj.SetActive(false);
        }
    }

    public void Retour()
    {
        foreach (GameObject Obj in objetADisparaitreRetour)
        {
            Obj.SetActive(false);
        }
    }

    public void FinOption()
    {
        foreach (GameObject Obj in objetAApparaitreRetour)
        {
            Obj.SetActive(true);
        }
    }

    public void RetourHistoire()
    {
        foreach (GameObject Obj in objetAApparaitreRetourHistoire)
        {
            Obj.SetActive(true);
        }

        foreach (GameObject Obj in objetADisparaitreRetourHistoire)
        {
            Obj.SetActive(false);
        }
    }
}
