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

    public void Niveau1()
    {
        SceneManager.LoadScene("niv-1");
    }

    public void Niveau2()
    {
        SceneManager.LoadScene("niv-2");
    }

    public void Niveau3()
    {
        SceneManager.LoadScene("niv-3");
    }

    public void Niveau4()
    {
        SceneManager.LoadScene("niv-4");
    }

    public void Niveau5()
    {
        SceneManager.LoadScene("niv-5");
    }
}
