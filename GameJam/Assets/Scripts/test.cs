using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public Text tt;
    public void click()
    {
        tt.text = "Hello";
        Debug.Log("hello");

    }
}
