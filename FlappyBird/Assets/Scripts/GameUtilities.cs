﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUtilities : MonoBehaviour
{
    public int getHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }

    public void saveHighScore(int val)
    {
        PlayerPrefs.SetInt("HighScore", val);
    }
}
