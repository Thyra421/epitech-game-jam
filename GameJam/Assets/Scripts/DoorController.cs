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
    private bool _isOpen;
    private bool _isHolding;
    private float _holdTime;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.transform.CompareTag("Player")) {
            return;
        }
        if (_isOpen) {
            doorLeft.Open();
            doorRight.Open();
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
            doorLeft.Open();
            doorRight.Open();
            hint.gameObject.SetActive(false);
            slider.gameObject.SetActive(false);
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
}
