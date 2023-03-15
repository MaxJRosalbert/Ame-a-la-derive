using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionBoutonsOption : MonoBehaviour
{
    public GameObject[] objetADisparaitreDroite;
    public GameObject[] objetAApparaitreDroite;

    public GameObject[] objetADisparaitreGauche;
    public GameObject[] objetAApparaitreGauche;

    public GameObject[] objetAApparaitreBtn1;
    public GameObject[] objetADisparaitreBtn1;

    public GameObject[] objetAApparaitreBtn2;
    public GameObject[] objetADisparaitreBtn2;

    public GameObject[] objetAApparaitreBtn3;
    public GameObject[] objetADisparaitreBtn3;
    
    public GameObject[] objetAApparaitreBtn4;
    public GameObject[] objetADisparaitreBtn4;
    
    public GameObject[] objetAApparaitreBtn5;
    public GameObject[] objetADisparaitreBtn5;

    public GameObject[] objetADisparaitreRetour;

    public void FlecheDroite()
    {
        foreach (GameObject Obj in objetADisparaitreDroite)
        {
            Obj.SetActive(false);
        }

        foreach (GameObject Obj in objetAApparaitreDroite)
        {
            Obj.SetActive(true);
        }
    }

    public void FlecheGauche()
    {
        foreach (GameObject Obj in objetADisparaitreGauche)
        {
            Obj.SetActive(false);
        }

        foreach (GameObject Obj in objetAApparaitreGauche)
        {
            Obj.SetActive(true);
        }
    }


    public void Niv1()
    {
        foreach (GameObject Obj in objetADisparaitreBtn1)
        {
            Obj.SetActive(false);
        }

        foreach (GameObject Obj in objetAApparaitreBtn1)
        {
            Obj.SetActive(true);
        }
    }

    public void Niv2()
    {
        foreach (GameObject Obj in objetADisparaitreBtn2)
        {
            Obj.SetActive(false);
        }

        foreach (GameObject Obj in objetAApparaitreBtn2)
        {
            Obj.SetActive(true);
        }
    }

    public void Niv3()
    {
        foreach (GameObject Obj in objetADisparaitreBtn3)
        {
            Obj.SetActive(false);
        }

        foreach (GameObject Obj in objetAApparaitreBtn3)
        {
            Obj.SetActive(true);
        }
    }

    public void Niv4()
    {
        foreach (GameObject Obj in objetADisparaitreBtn4)
        {
            Obj.SetActive(false);
        }

        foreach (GameObject Obj in objetAApparaitreBtn4)
        {
            Obj.SetActive(true);
        }
    }

    public void Niv5()
    {
        foreach (GameObject Obj in objetADisparaitreBtn5)
        {
            Obj.SetActive(false);
        }

        foreach (GameObject Obj in objetAApparaitreBtn5)
        {
            Obj.SetActive(true);
        }
    }

    public void Retour()
    {
        foreach (GameObject Obj in objetADisparaitreRetour)
        {
            Obj.SetActive(false);
        }
    }
}
