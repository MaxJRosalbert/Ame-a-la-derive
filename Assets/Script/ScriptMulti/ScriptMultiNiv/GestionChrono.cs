using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GestionChrono : MonoBehaviour
{
    public TextMeshProUGUI texteChrono;
    public float chrono = 0;
    public bool chronoEnCours = true;

    void Start()
    {
       chronoEnCours = true;

    }

    void Update()
    {
        if (chronoEnCours)
        {
            if( chrono >= 0)
            {
                chrono += Time.deltaTime;
                DisplayTime(chrono);
            }
        }
    }
    void DisplayTime(float tempsASeparer)
    {
        tempsASeparer += 1;

        string minutes = ((int)tempsASeparer / 60).ToString();
        string secondes = (tempsASeparer % 60).ToString("f2");

        texteChrono.text = minutes + ":" + secondes;


        //float minutes = Mathf.FloorToInt(tempsASeparer/60);
        //float secondes = Mathf.FloorToInt(tempsASeparer%60);
        //texteChrono.text = string.Format("{00:00} : {01:00}",minutes, secondes);
    }

    public void ChronoPause()
    {
        chronoEnCours = false;
    }

    public void Chronoreprise()
    {
        chronoEnCours = true;
    }


}

