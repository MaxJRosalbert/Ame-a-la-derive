using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionInteraction : MonoBehaviour
{

    public GameObject dialogue1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Invoke("BoiteDialogueNiv",0f);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Invoke("BoiteDialogueNiv", 0f);
        }

    }

    public void BoiteDialogueNiv()
    {
        dialogue1.SetActive(true);
    }
}
