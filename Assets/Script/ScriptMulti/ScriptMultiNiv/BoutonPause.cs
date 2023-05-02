using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoutonPause : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //gameObject.GetComponent<MenuPause>().InterfacePause();
            gameObject.GetComponent<GestionChrono>().ChronoPause();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;

            if (GetComponent<DeplacementSjel>().auSol == false) {
                //GetComponent<DeplacementSjel>().gravite = 9f;
                //GetComponent<DeplacementSjelSimple>().gravite = 9f;
            }
        }
    }

    public void ReprendrePartie()
    {
        Time.timeScale = 1;
    }
}
