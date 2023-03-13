using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GestionCredit : MonoBehaviour
{
    float time;
    public float TimerInterval = 5;
    float tick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        time = (int)Time.time;
        tick = TimerInterval;
    }

    // Update is called once per frame
    void Update()
    {
        print(time);

        time = (int)Time.time;

        if(time == tick)
        {
            tick = time + TimerInterval;
            Debug.Log("Timer");
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0) || time == 10)
        {
            GetComponent<Animator>().SetTrigger("FinVideo");
            Invoke("RetourIntro", 1);
        }

    }

    void RetourIntro()
    {
        SceneManager.LoadScene("Intro");
    }
}
