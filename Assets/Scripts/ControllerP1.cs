using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerP1 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        foreach(Touch touch in Input.touches)
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(touch.position);

            if(pos.x < -1)
            {
                pos.x = -9;
                transform.position = pos;
            }
        }
    }
}
