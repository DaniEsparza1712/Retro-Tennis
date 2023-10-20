using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBGColor : MonoBehaviour
{
    public Camera cam;
    public Color[] colores;
    int colorID = 0;

    void Update()
    {
        StartCoroutine(ChangeBG());
    }
    IEnumerator ChangeBG()
    {
        cam.backgroundColor = colores[colorID];
        if(colorID < colores.Length - 1)
        {
            colorID += 1;
        }
        else
        {
            colorID = 0;
        }
        yield return new WaitForSeconds(2);
    }
}
