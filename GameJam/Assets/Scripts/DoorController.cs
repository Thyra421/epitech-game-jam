using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorController : MonoBehaviour
{
    public Door doorLeft;
    public Door doorRight;
    private bool _isOpen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player") && _isOpen) {
            doorLeft.Open();
            doorRight.Open();
            Debug.Log("Opening door");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!_isOpen && Input.GetKey(KeyCode.Tab)) {
            _isOpen = true;
            doorLeft.Open();
            doorRight.Open();
            Debug.Log("Opening door");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player")) {
            doorLeft.Close();
            doorRight.Close();
        }
        Debug.Log("Closing door");
    }
}
