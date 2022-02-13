using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    public Door doorLeft;
    public Door doorRight;
    public Slider slider;
    public Text hint;
    public AudioSource sound;
    public Rigidbody player;
    public Transform pressureSource;
    public Animator fadeIn;
    public bool isSafe;
    private bool _isOpen;
    private bool _isHolding;
    private float _holdTime;
    


    private void OnTriggerEnter(Collider other)
    {
        if (!other.transform.CompareTag("Player")) {
            return;
        }
        if (_isOpen) {
            Open();
        } else {
            hint.text = "Hold tab to open the door";
            hint.gameObject.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)

    {
        if (_isOpen || !other.transform.CompareTag("Player"))
            return;

        if (_holdTime >= 3) {
            _isOpen = true;
            hint.gameObject.SetActive(false);
            slider.gameObject.SetActive(false);
            Open();
        } else if (Input.GetKey(KeyCode.Tab)) {
            slider.gameObject.SetActive(true);
            _holdTime += Time.deltaTime;
            slider.value = _holdTime / 3;
        } else {
            _holdTime = 0;
            slider.value = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player")) {
            hint.gameObject.SetActive(false);
            slider.gameObject.SetActive(false);
            doorLeft.Close();
            doorRight.Close();
        }
    }

    private void Open()
    {
        doorLeft.Open();
        doorRight.Open();
        sound.Play();
        if (!isSafe)
            Pressure();
    }

    private void Pressure()
    {
        Debug.Log("pressure");
        player.AddForce((pressureSource.position - player.position) * 200);
        fadeIn.SetTrigger("Fade");
    }

    private void Reset()
    {
        
    }
}