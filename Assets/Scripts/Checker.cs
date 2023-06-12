using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker
{
    public Checker()
    {

    }

    public bool CheckAnswer(string answer, string suggestion)
    {
        return answer == suggestion;
    }
}
