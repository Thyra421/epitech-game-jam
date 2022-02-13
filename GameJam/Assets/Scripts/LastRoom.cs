using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastRoom : MonoBehaviour
{
    public Animator anim;
    
    private void OnTriggerEnter(Collider other)
    {
        anim.SetTrigger("Fade");
        Invoke(nameof(KEKW), 1.5f);
    }

    private void KEKW()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("End");
    }
}
