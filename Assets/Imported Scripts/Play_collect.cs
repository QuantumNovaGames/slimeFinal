using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_collect : MonoBehaviour
{
    public int numberofCrystals { get; private set; }

    public void crystalsCollected()
    {
        ScoreScript.score++;
    }
}
