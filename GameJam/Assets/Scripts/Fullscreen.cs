using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Fullscreen : MonoBehaviour
{
    public void Switch()
    {
        if (Screen.fullScreen == false)
            Screen.fullScreen = true;
        else
            Screen.fullScreen = false;
    }
}
