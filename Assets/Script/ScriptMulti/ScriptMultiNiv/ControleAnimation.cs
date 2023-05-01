using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleAnimation : MonoBehaviour
{
    public GameObject perso;

    void Update()
    {
        if (GetComponent<DeplacementSjelSimple>().auSol == true)
        {
            gameObject.GetComponent<Animator>().SetBool("saut", false);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            gameObject.GetComponent<Animator>().SetBool("saut", false);
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            gameObject.GetComponent<Animator>().SetBool("deplace", true);
        }
        else
        {
            gameObject.GetComponent<Animator>().SetBool("deplace", false);
        }

    }
}
