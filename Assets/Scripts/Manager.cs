using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public Text p1PointsUI;
    public Text p2PointsUI;
    public Text counterUI;

    public AudioClip[] musicArray;
    public AudioClip countClip;
    AudioSource audioSource;
    public AudioSource audioSource2;

    public GameObject line;

    public int p1Points;
    public int p2Points;
    public int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = musicArray[Random.Range(0, 3)];
        audioSource.volume = PlayerPrefs.GetFloat("MusicVolume", 5) / 10;
        audioSource.Play();

        Instantiate(line, Vector2.zero, Quaternion.identity);
    }
    public IEnumerator CountForRound()
    {
        for(int i = 0; i < 3; i++)
        {
            audioSource2.PlayOneShot(countClip, PlayerPrefs.GetFloat("SFXVolume") / 10);
            yield return new WaitForSeconds(1);
            counter -= 1;
        }       
    }
    // Update is called once per frame
    void Update()
    {
        p1PointsUI.text = p1Points.ToString();
        p2PointsUI.text = p2Points.ToString();
        if(counter > 0)
        {
            counterUI.text = counter.ToString();
        }
        else
        {
            counterUI.text = "";
        }
        if(p1Points == PlayerPrefs.GetInt("maxScore", 5))
        {
            PlayerPrefs.SetInt("p1Points", p1Points);
            PlayerPrefs.SetInt("p2Points", p2Points);
            PlayerPrefs.SetInt("winner", 1);
            SceneManager.LoadScene("Results", LoadSceneMode.Single);
        }
        else if(p2Points == PlayerPrefs.GetInt("maxScore", 5))
        {
            PlayerPrefs.SetInt("p1Points", p1Points);
            PlayerPrefs.SetInt("p2Points", p2Points);
            PlayerPrefs.SetInt("winner", 2);
            SceneManager.LoadScene("Results", LoadSceneMode.Single);
        }
    }
}
