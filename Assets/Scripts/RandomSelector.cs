using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSelector
{
    public RandomSelector()
    {

    }

    public string[] SelectRandom()
    {
        int randomIndex = Random.Range(0, Data.data.GetLength(0));
        int itemlength = Data.data.GetLength(1);
        string[] selected = new string[itemlength];    


        for (int i = 0; i < itemlength; i++)
        {
            selected[i] = Data.data[randomIndex, i];
        }

        if (Random.Range(0, 101) > 50)
        {
            selected[0] = selected[1];
        }

       

        return selected;
    }
}
