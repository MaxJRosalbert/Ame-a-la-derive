using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GestionVieSonic : MonoBehaviour
{
    public float viePerso = 5;
    public float vieTotal = 10;
    public float dommage = 2;
    public float boost = 1;

    public GameObject flammeP;
    public GameObject dialogue;


    public TextMeshProUGUI compteurVie;

    // Start is called before the first frame update
    void Start()
    {
        flammeP.GetComponent<Animator>().SetBool("FlammeAllumee", true);

        flammeP.GetComponent<Animator>().SetBool("FlammeMorte", false);

        compteurVie.text = viePerso.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Invoke("PertePointsVie", 0f);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Invoke("GagnePointsVie", 0f);
        }
    }

    void OnCollisionEnter(Collision infoCollision)
    {
        // Si le terrain est touché alors active l'animation de l'objet et détruit le
        if (infoCollision.gameObject.tag == "ennemi")
        {
            Invoke("PertePointsVie", 0f);
            print("vie verdu");

        }

    }

    public void PertePointsVie()
    {
        if (viePerso <= vieTotal && viePerso > 0)
        {
            viePerso = viePerso -dommage;
            dialogue.SetActive(true);

            if (viePerso <= 0)
            {
                Invoke("FlammePEteinte", 0f);
                viePerso = 0;
            }
        }

        

        compteurVie.text = viePerso.ToString();
    }

    public void GagnePointsVie()
    {
        if (viePerso < vieTotal && viePerso > 0)
        {
            viePerso = viePerso + boost;

            if (viePerso > vieTotal)
            {
                viePerso = vieTotal;
            }
        }


        compteurVie.text = viePerso.ToString();
    }

    public void FlammePEteinte()
    {
        flammeP.GetComponent<Animator>().SetTrigger("Flamme");
        Invoke("FlammePmorte", 0.35f);
    }
    public void FlammePmorte()
    {
        flammeP.GetComponent<Animator>().SetBool("FlammeAllumee", false);
        flammeP.GetComponent<Animator>().SetBool("FlammeMorte", true);
    }

}
