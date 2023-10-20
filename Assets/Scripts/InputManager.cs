using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    public InputField inputField;
    public void ScoreToWin()
    {
        PlayerPrefs.SetInt("maxScore", int.Parse(inputField.text));
    }
}
