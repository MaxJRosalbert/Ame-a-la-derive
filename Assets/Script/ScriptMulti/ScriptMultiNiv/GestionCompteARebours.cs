using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GestionCompteARebours : MonoBehaviour
{
    public TextMeshProUGUI compteurTxT;
    public TextMeshProUGUI compteurScore;

    public GameObject Personnage;

    public GameObject[] objetADisparaitre;
    public GameObject[] objetAApparaitre;

    
    float compteur = 10;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (Chrono ());
        compteur += 1;
        //compteurTxT.text = compteur.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Chrono()
    {


        while (compteur > 0)
        {
            compteur--;
            yield return new WaitForSeconds(1f);


            compteurTxT.text = string.Format ("{0:0}:{1:00}", Mathf.Floor(compteur / 60), compteur % 60);
        }
        
        if(compteur == 0)
        {
            Invoke("Terminer", 0);
        }

    }

    public void Terminer()
    {
        compteurScore.transform.position = new Vector2(775, 370);

        foreach (GameObject Obj in objetADisparaitre)
        {
            Obj.SetActive(false);
        }

        foreach (GameObject Obj in objetAApparaitre)
        {
            Obj.SetActive(true);
        }

        Personnage.SetActive(false);
    }

}
  
