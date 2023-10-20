using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    public string prefName;
    public Slider slider;
    public void SetCPULevel()
    {
        if(slider.value == 1)
        {
            PlayerPrefs.SetInt("CPULevel", 1);
            PlayerPrefs.SetFloat("offset", 0.75f);
            PlayerPrefs.SetFloat("reaction distance", 2f);
            PlayerPrefs.Save();
        }
        else if(slider.value == 2)
        {
            PlayerPrefs.SetInt("CPULevel", 2);
            PlayerPrefs.SetFloat("offset", 0.75f);
            PlayerPrefs.SetFloat("reaction distance", 0.75f);
            PlayerPrefs.Save();
        }
        else if(slider.value == 3)
        {
            PlayerPrefs.SetInt("CPULevel", 3);
            PlayerPrefs.SetFloat("offset", 0.5f);
            PlayerPrefs.SetFloat("reaction distance", 1f);
            PlayerPrefs.Save();
        }
    }
    public void SetVolume()
    {
        PlayerPrefs.SetFloat(prefName, slider.value);
        PlayerPrefs.Save();
    }
}
