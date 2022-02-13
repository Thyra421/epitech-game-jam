using System;
using UnityEngine;
using UnityEngine.UI;

public class RadioController : MonoBehaviour
{
    public Text hint;
    public AudioSource sound;

    private void OnTriggerEnter(Collider other)
    {
        hint.text = "Press tab to play the radio";
        hint.gameObject.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            sound.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        hint.gameObject.SetActive(false);
    }
}
