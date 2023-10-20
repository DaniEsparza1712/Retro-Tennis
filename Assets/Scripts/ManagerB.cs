using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerB : MonoBehaviour
{
    public AudioSource audioSource;
    // Update is called once per frame
    void Start()
    {
        audioSource.volume = PlayerPrefs.GetFloat("MusicVolume", 5) / 10;
        if (PlayerPrefs.GetInt("Privacy", 1) == 1)
        {
            SceneManager.LoadScene("Disclosure");
        }
    }
}
