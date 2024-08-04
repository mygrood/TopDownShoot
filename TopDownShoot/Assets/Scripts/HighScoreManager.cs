using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HighScoreManager
{
    //���������� ������� � PlayerPrefs
    public static void SaveHighScore(int score)
    {
        int currentHighScore = PlayerPrefs.GetInt("HighScore");
        if (score > currentHighScore)
        {
            PlayerPrefs.SetInt("HighScore", score);           
            PlayerPrefs.Save();
            Debug.Log("NEW Highscore:" + score);
        }
    }

    //��������� ������� �� PlayerPrefs
    public static int GetHighScore() 
    {
       Debug.Log("Highscore "+ PlayerPrefs.GetInt("HighScore"));
       return PlayerPrefs.GetInt("HighScore");
    }
        

}
