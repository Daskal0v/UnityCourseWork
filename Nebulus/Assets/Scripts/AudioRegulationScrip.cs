using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioRegulationScrip : MonoBehaviour {
    Slider volumeSlider;
    public void SetAudioVolume()
    {
        GameObject audio = GameObject.Find("VolumeSlider");
        if (audio != null)
        {
            volumeSlider = audio.GetComponent<Slider>();
            PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        }
    }
}
