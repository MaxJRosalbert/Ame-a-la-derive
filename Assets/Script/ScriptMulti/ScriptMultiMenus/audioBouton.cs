using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioBouton : MonoBehaviour
{
    public AudioSource FxBtn;
    public AudioClip hoverFx;
    public AudioClip ClickFx;

    public void HoverSound()
    {
        FxBtn.PlayOneShot(hoverFx);
        print(hoverFx);
    }

    public void ClickSound()
    {
        FxBtn.PlayOneShot(ClickFx);
        print(ClickFx);
    }
}
