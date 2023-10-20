using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerD : MonoBehaviour
{
    public AudioSource audioSource;
    public InputField scoreToWin;
    public Slider levelCPU;
    public Slider volumeSFX;
    public Slider volumeMusic;
    private void Start()
    {
        audioSource.volume = PlayerPrefs.GetFloat("MusicVolume", 5) / 10;
        scoreToWin.text = PlayerPrefs.GetInt("maxScore", 5).ToString();
        levelCPU.value = PlayerPrefs.GetInt("CPULevel", 2);
        volumeSFX.value = PlayerPrefs.GetFloat("SFXVolume", 5);
        volumeMusic.value = PlayerPrefs.GetFloat("MusicVolume", 5);
    }
}
