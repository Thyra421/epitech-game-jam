using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_scene : MonoBehaviour
{
    public string scene;
    public void Load()
    {
        SceneManager.LoadScene(scene);
    }
}