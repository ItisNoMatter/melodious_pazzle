using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{

    [SerializeField]
    UnityEngine.Audio.AudioMixer mixer;

    [SerializeField]
    Slider slider;


    private void Start()
    {
        slider.onValueChanged.AddListener(delegate { volumeChange(); });

    }

    public void volumeChange()
    {
        mixer.SetFloat("BGM", slider.value);
        mixer.SetFloat("SE", slider.value);
    }

}