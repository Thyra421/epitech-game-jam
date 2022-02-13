using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Sound_effect : MonoBehaviour
{
    public AudioSource ad;
    // Start is called before the first frame update
    public void play()
    {
        ad.Play();
    }
}