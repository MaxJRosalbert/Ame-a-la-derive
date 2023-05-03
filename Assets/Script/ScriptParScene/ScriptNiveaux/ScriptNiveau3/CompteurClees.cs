using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CompteurClees : MonoBehaviour
{

    public TextMeshProUGUI compteurScore;
    public AudioClip SonPiece;
    float scoreClee = 0;
    public float Nbreclee;
    public GameObject text1;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && scoreClee < Nbreclee)
        {
            scoreClee++;
            GetComponent<AudioSource>().PlayOneShot(SonPiece);

            if (scoreClee == 5)
            {
                Invoke("FinClee", 0f);
            }
        }

        compteurScore.text = scoreClee.ToString();
    }

    void FinClee()
    {
        text1.SetActive(true);
    }

    /**void OnCollisionEnter(Collision infoCollision)
    {
        if (infoCollision.gameObject.tag == "Or")
        {
            
        }
    }*/
}
