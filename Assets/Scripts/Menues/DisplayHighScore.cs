using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayHighScore : MonoBehaviour
{
    

    private void Start()
    {
        TMP_Text text = GetComponent<TMP_Text>();
        text.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}
