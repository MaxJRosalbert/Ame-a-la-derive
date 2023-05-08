using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionInteraction : MonoBehaviour
{
    bool bulleDialogue1 = false;
    bool bulleDialogue2 = false;
    bool bulleDialogue3 = false;

    public GameObject dialogue1;
    public GameObject dialogue2;
    public GameObject dialogue3;

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
<<<<<<< HEAD
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (bulleDialogue1 == false)
            {
                Invoke("OBoiteDialoguePS", 0f);
                bulleDialogue1 = true;
            }
            else
            {
                Invoke("FBoiteDialoguePS", 0f);
                bulleDialogue1 = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            if (bulleDialogue2 == false)
            {
                Invoke("OBoiteDialogueP2", 0f);
                bulleDialogue2 = true;
            }
            else
            {
                Invoke("FBoiteDialogueP2", 0f);
                bulleDialogue2 = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            if (bulleDialogue3 == false)
            {
                Invoke("OBoiteDialoguePNJ", 0f);
                bulleDialogue3 = true;
            }
            else
            {
                Invoke("FBoiteDialoguePNJ", 0f);
                bulleDialogue3 = false;
            }
        }

    }

    public void OBoiteDialoguePS()
    {
        dialogue1.SetActive(true);
    }

    public void OBoiteDialogueP2()
    {
        dialogue2.SetActive(true);
    }

    public void OBoiteDialoguePNJ()
    {
        dialogue3.SetActive(true);
    }

    public void FBoiteDialoguePS()
    {
        dialogue1.SetActive(false);
    }

    public void FBoiteDialogueP2()
    {
        dialogue2.SetActive(false);
    }

    public void FBoiteDialoguePNJ()
    {
        dialogue3.SetActive(false);
    }
=======
        

    }


>>>>>>> f754d5ba98bcdd50b3a625b7c81bac4828ed0a5d
=======
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
>>>>>>> parent of 111401e (fin integration menu pause et tentative de gestion de dialogue)
}
