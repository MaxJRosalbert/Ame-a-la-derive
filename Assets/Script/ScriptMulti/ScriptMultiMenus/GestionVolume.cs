using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GestionVolume : MonoBehaviour
{

    public Scrollbar AudioSlider;
    public Scrollbar SfxSlider;

    // Start is called before the first frame update
    void Start()
    {
        float VolumeAudio = PlayerPrefs.GetFloat("VolumeAudio", 0.5f);
        AudioSlider.value = VolumeAudio;

        float VolumeSfx = PlayerPrefs.GetFloat("VolumeSfx", 0.5f);
        SfxSlider.value = VolumeSfx;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolumeAudio()
    {
        AudioListener.volume = AudioSlider.value;
        PlayerPrefs.SetFloat("VolumeAudio", AudioSlider.value);
    }

    public void SetVolumeSfx()
    {
        AudioListener.volume = SfxSlider.value;
        PlayerPrefs.SetFloat("VolumeSfx", SfxSlider.value);
    }
}
