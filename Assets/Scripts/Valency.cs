using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valency : MonoBehaviour
{
    RandomSelector rndSelector = new RandomSelector();
    Checker checker = new Checker();
    Display display;


    int score = 0;
    int highScore=0;

    string question;
    string symbol;
    string suggestion;
    string answer;

    public float wrongWaitTime = 2f;
    public float rightWaitTime = 2f;
    bool waiting;
    float timer;
    

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        
        display = GetComponent<Display>();
        SetQAndA();

    }

    private void Update()
    {
        Timer();
    }

    void SetQAndA()
    {
        string[] components = rndSelector.SelectRandom();
        question = components[0];
        symbol = components[1];
        answer = components[2];

        display.SetText(question);
    }

    public void EnterSuggestion(string suggest)
    {
        suggestion = suggest;
        FindSolution();
    }

    void FindSolution()
    {
        if (checker.CheckAnswer(answer, suggestion)) 
        {
            OnSuccess();
        }
        else
        {
            OnFail();
        }
    }

    void OnSuccess()
    {
        score++;
        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        
        display.OnSolutionCalculated(true, symbol,answer, score, highScore);       
        timer = rightWaitTime;
        waiting = true;
    }

    private void OnFail()
    {
        score = 0;
        display.OnSolutionCalculated(false, symbol, answer, score, highScore);
        timer = wrongWaitTime;
        waiting = true;
    }

    void Timer()
    {
        if (waiting)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                display.Restart();
                SetQAndA();
                waiting = false;
            }
        }
    }
}
