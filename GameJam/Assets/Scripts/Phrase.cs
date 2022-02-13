using UnityEngine;
using System.Collections;
using System;
using System.IO;
using UnityEngine.UI;
using UnityEngine;
public class Phrase : MonoBehaviour
{
    public Text phrase;

    public string GetRandomPhrase()
    {
        System.Random a = new System.Random();
        string fileName = "Assets/Scripts/file.txt";
        string[] lines = File.ReadAllLines(fileName);
        return lines[a.Next(6)];
    }
}