using System;
using UnityEngine;

public class EnvironmentColorController : MonoBehaviour
{
    public enum Color
    {
        red, blue, green, yellow, cyan, magenta
    }

    public Color color;

    private void OnTriggerEnter(Collider other)
    {
        switch (color) {
            case Color.blue:
                RenderSettings.ambientLight = UnityEngine.Color.blue;
                break;
            case Color.red:
                RenderSettings.ambientLight = UnityEngine.Color.red;
                break;
            case Color.green:
                RenderSettings.ambientLight = UnityEngine.Color.green;
                break;
            case Color.yellow:
                RenderSettings.ambientLight = UnityEngine.Color.yellow;
                break;
            case Color.cyan:
                RenderSettings.ambientLight = UnityEngine.Color.cyan;
                break;
            case Color.magenta:
                RenderSettings.ambientLight = UnityEngine.Color.magenta;
                break;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        RenderSettings.ambientLight = UnityEngine.Color.white;
    }

    public static void Reset()
    {
        RenderSettings.ambientLight = UnityEngine.Color.white;
    }
}
