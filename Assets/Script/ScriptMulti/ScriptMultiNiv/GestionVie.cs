using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionVie : MonoBehaviour
{
    public GameObject flamme1;
    public GameObject flamme2;
    public GameObject flamme3;
    public float vie = 3;
    public GameObject Perso;
    // Start is called before the first frame update
    void Start()
    {
        flamme1.GetComponent<Animator>().SetBool("FlammeAllumee", true);
        flamme2.GetComponent<Animator>().SetBool("FlammeAllumee", true);
        flamme3.GetComponent<Animator>().SetBool("FlammeAllumee", true);

        flamme1.GetComponent<Animator>().SetBool("FlammeMorte", false);
        flamme2.GetComponent<Animator>().SetBool("FlammeMorte", false);
        flamme3.GetComponent<Animator>().SetBool("FlammeMorte", false);

    }

     void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Invoke("PerteVie", 0f);
            vie--;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Invoke("Gagnevie", 0f);
            vie++;
            if(vie > 3)
            {
                vie = 3;
            }
        }
    }

    public void PerteVie()
    {
        
        if (vie == 2)
        {
            Invoke("FlammeEteinte1", 0f);
        }

        if (vie == 1)
        {
            Invoke("FlammeEteinte2", 0f);
        }

        if (vie == 0)
        {
            Invoke("FlammeEteinte3", 0f);
        }
    }

    public void Gagnevie()
    {
        if (vie == 3)
        {
            Invoke("FlammeAllumee1", 0f);
        }
        if (vie == 2)
        {
            Invoke("FlammeAllumee2", 0f);
        }
        
    }



    public void FlammeEteinte1()
    {
        flamme1.GetComponent<Animator>().SetTrigger("Flamme");
        Invoke("Flammemorte1", 0.35f);
    }
    public void Flammemorte1()
    {
        flamme1.GetComponent<Animator>().SetBool("FlammeAllumee", false);
        flamme1.GetComponent<Animator>().SetBool("FlammeMorte", true);
    }
    public void FlammeAllumee1()
    {
        flamme1.GetComponent<Animator>().SetBool("FlammeAllumee", true);
        flamme1.GetComponent<Animator>().SetBool("FlammeMorte", true);
        Invoke("FlammeVive1", 1f);
    }
    public void FlammeVive1()
    {
        flamme1.GetComponent<Animator>().SetBool("FlammeAllumee", true);
        flamme1.GetComponent<Animator>().SetBool("FlammeMorte", false);
    }


    public void FlammeEteinte2()
    {
        flamme2.GetComponent<Animator>().SetTrigger("Flamme");
        Invoke("Flammemorte2", 0.35f);
    }
    public void Flammemorte2()
    {
        flamme2.GetComponent<Animator>().SetBool("FlammeAllumee", false);
        flamme2.GetComponent<Animator>().SetBool("FlammeMorte", true);
    }
    public void FlammeAllumee2()
    {
        flamme2.GetComponent<Animator>().SetBool("FlammeAllumee", true);
        flamme2.GetComponent<Animator>().SetBool("FlammeMorte", true);
        Invoke("FlammeVive2", 1f);
    }
    public void FlammeVive2()
    {
        flamme2.GetComponent<Animator>().SetBool("FlammeAllumee", true);
        flamme2.GetComponent<Animator>().SetBool("FlammeMorte", false);
    }


    public void FlammeEteinte3()
    {
        flamme3.GetComponent<Animator>().SetTrigger("Flamme");
        Invoke("Flammemorte3", 0.35f);
    }
    public void Flammemorte3()
    {
        flamme3.GetComponent<Animator>().SetBool("FlammeAllumee", false);
        flamme3.GetComponent<Animator>().SetBool("FlammeMorte", true);
    }
    public void FlammeAllumee3()
    {
        flamme3.GetComponent<Animator>().SetBool("FlammeAllumee", true);
        flamme3.GetComponent<Animator>().SetBool("FlammeMorte", true);
        Invoke("FlammeVive3", 1f);
    }
    public void FlammeVive3()
    {
        flamme3.GetComponent<Animator>().SetBool("FlammeAllumee", true);
        flamme3.GetComponent<Animator>().SetBool("FlammeMorte", false);
    }

    
}
