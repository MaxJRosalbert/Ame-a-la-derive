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
        SceneManager.LoadScene("Choix-Niv");
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
        SceneManager.LoadScene("niveau-1");
    }

    public void Niveau2()
    {
        SceneManager.LoadScene("niveau-2");
    }

    public void Niveau3()
    {
        SceneManager.LoadScene("niveau-3");
    }

    public void Niveau4Proto()
    {
        SceneManager.LoadScene("niveau-4-proto");
    }

    public void Niveau4Final()
    {
        SceneManager.LoadScene("Niveau-4-final");
    }

    public void Niveau5()
    {
        SceneManager.LoadScene("niveau-5");
    }
}
