using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VSButton : MonoBehaviour
{
    public AudioSource audioSource;
    public void loadPlayer()
    {
        audioSource.volume = PlayerPrefs.GetFloat("SFXVolume", 5) / 10;
        audioSource.Play();
        PlayerPrefs.SetInt("isPlayer2", 1);
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
    public void loadCPU()
    {
        audioSource.volume = PlayerPrefs.GetFloat("SFXVolume", 5) / 10;
        audioSource.Play();
        PlayerPrefs.SetInt("isPlayer2", 0);
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
    public void loadConfig()
    {
        audioSource.volume = PlayerPrefs.GetFloat("SFXVolume", 5) / 10;
        audioSource.Play();
        SceneManager.LoadScene("Config", LoadSceneMode.Single);
    }
    public void Continue()
    {
        audioSource.volume = PlayerPrefs.GetFloat("SFXVolume", 5) / 10;
        audioSource.Play();
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    public void Home()
    {
        audioSource.volume = PlayerPrefs.GetFloat("SFXVolume", 5) / 10;
        audioSource.Play();
        PlayerPrefs.Save();
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    public void AcceptPrivacy()
    {
        audioSource.volume = PlayerPrefs.GetFloat("SFXVolume", 5) / 10;
        audioSource.Play();
        PlayerPrefs.SetInt("Privacy", 0);
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    public void LoadPrivacy()
    {
        audioSource.volume = PlayerPrefs.GetFloat("SFXVolume", 5) / 10;
        audioSource.Play();
        SceneManager.LoadScene("Disclosure", LoadSceneMode.Single);
    }
    public void LinkToPolicy()
    {
        Application.OpenURL("https://unity3d.com/legal/privacy-policy");
    }
}
