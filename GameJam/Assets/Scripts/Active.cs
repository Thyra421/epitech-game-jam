using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Active : MonoBehaviour
{
    public GameObject menu;
    public bool val;

    public void Click()
    {
        menu.SetActive(val);
        Debug.Log("yes");

    }
}