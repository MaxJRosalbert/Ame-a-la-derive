using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GestionCredit : MonoBehaviour
{

    float compteur = 60;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Chrono());
        compteur += 1;
    }

    // Update is called once per frame
    void Update()
    {
        print(compteur);


        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetComponent<Animator>().SetTrigger("FinVideo");
            Invoke("RetourIntro", 1);
        }

    }

    IEnumerator Chrono()
    {


        while (compteur > 0)
        {
            compteur--;
            yield return new WaitForSeconds(1f);

        }

        if (compteur == 0)
        {
            Invoke("RetourIntro", 1);
        }

    }

    void RetourIntro()
    {
        SceneManager.LoadScene("Intro");
        compteur = 60;
        print(compteur);
    }
}
