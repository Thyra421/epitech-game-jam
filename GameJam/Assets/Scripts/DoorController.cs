using System;
using StarterAssets;
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
    public MoneyController money;
    public ThirdPersonController controller;
    public Phrase phrase;
    public bool isSafe;
    private bool _isOpen;
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
            Close();
        }
    }

    void Close()
    {
        hint.gameObject.SetActive(false);
        slider.gameObject.SetActive(false);
        doorLeft.Close();
        doorRight.Close();
    }

    private void Open()
    {
        doorLeft.Open();
        doorRight.Open();
        sound.Play();
        if (!isSafe) {
            Invoke(nameof(Pressure), .25f);
        }
    }

    private void Pressure()
    {
        EnvironmentColorController.Reset();
        controller.EnableController(false);
        controller.Push();
        Debug.Log("pressure");
        player.AddForce((pressureSource.position - player.position) * 80);
        fadeIn.SetTrigger("Fade");
        money.Remove(50000);
        Invoke(nameof(Reset), 2);
    }

    private void Reset()
    {
        Close();
        controller.Reset();
        player.velocity = Vector3.zero;
        controller.EnableController(true);
        _isOpen = false;
        _holdTime = 0;
        phrase.SetPhrase();
    }
}