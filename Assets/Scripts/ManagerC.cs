using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerC : MonoBehaviour
{
    public AudioSource audioSource;
    public Text winnerB;
    public Text p1ScoreB;
    public Text p2ScoreB;

    void Start()
    {
        audioSource.volume = PlayerPrefs.GetFloat("MusicVolume", 5) / 10;

        winnerB.text = "Player " + PlayerPrefs.GetInt("winner", 1).ToString();
        p1ScoreB.text = PlayerPrefs.GetInt("p1Points", 0).ToString();
        p2ScoreB.text = PlayerPrefs.GetInt("p2Points", 0).ToString();
    }
}
