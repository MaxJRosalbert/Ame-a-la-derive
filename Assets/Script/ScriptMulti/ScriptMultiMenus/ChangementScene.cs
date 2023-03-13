using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangementScene : MonoBehaviour
{
    public void SceneIntro()
    {
        SceneManager.LoadScene("Intro");
    }

    public void SceneChoixNiv()
    {
        SceneManager.LoadScene("choix-Niv");
    }

    public void SceneOption()
    {
        SceneManager.LoadScene("Option");
    }

    public void SceneCredit()
    {
        SceneManager.LoadScene("Credit");
    }

}
