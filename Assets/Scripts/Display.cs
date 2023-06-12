using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Display : MonoBehaviour
{
    //int score = 0;

    TMP_Text mainText;
    TMP_Text tScore;
    TMP_Text tHighScore;
    public GameObject scoreObject;
    public GameObject highScoreObject;
    public GameObject display;
    public GameObject wrong;
    public GameObject right;
    public GameObject buttons;

    private void Start()
    {
        mainText = display.GetComponent<TMP_Text>();
        tScore = scoreObject.GetComponent<TMP_Text>();
        tHighScore = highScoreObject.GetComponent<TMP_Text>();
        mainText.text = "";
        tScore.text = "Score: 0";
        tHighScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        Restart();
    }

    public void Restart()
    {
        wrong.SetActive(false);
        right.SetActive(false);
        display.SetActive(true);
        buttons.SetActive(true);

    }

    public void SetText(string s)
    {
        char[] characters = s.ToCharArray();
        string displayString = "";
        int num;

        for (int i = 0; i < characters.Length; i++)
        {
            string nextPart = "";
            bool parsable = Int32.TryParse(characters[i].ToString(), out num);
            if (parsable)
            {
                nextPart = string.Format("<sub>{0}</sub>", characters[i].ToString());
            }
            else
            {
                nextPart = characters[i].ToString();
            }

            displayString += nextPart;
        }

        mainText.text = displayString;
    }

    public void OnSolutionCalculated(bool correct, string symbol, string value, int score, int highScore)
    {
        //display.SetActive(false);
        buttons.SetActive(false);
        if (correct)
        { 
            right.SetActive(true);
            DisplayAnswer(symbol, value, score, highScore);
        }
        else
        {
            wrong.SetActive(true);
            DisplayAnswer(symbol, value, score, highScore);
        }

       

    }

    void DisplayAnswer(string symbol, string value, int score, int highScore)
    {
        tScore.text = "Score: " + score.ToString();
        tHighScore.text = "High Score: " + highScore.ToString();

        char[] characters = symbol.ToCharArray();
        string displayString = "";
        int num;

        for (int i = 0; i < characters.Length; i++)
        {
            string nextPart = "";
            bool parsable = Int32.TryParse(characters[i].ToString(), out num);
            if (parsable)
            {
                nextPart = string.Format("<sub>{0}</sub>", characters[i].ToString());
            }
            else
            {
                nextPart = characters[i].ToString();
            }

            displayString += nextPart;
        }

        displayString += string.Format("<sup>{0}</sup>", value);
        //Debug.Log(displayString);
        mainText.text = displayString;
    }
  
}
