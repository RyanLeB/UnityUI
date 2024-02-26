using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    public int currentScore;
    public TMP_Text scoreCount;
    


    private void Awake()
    {
        scoreCount.text = currentScore.ToString();
        
    }


    public void ScoreUpdater(int value)
    {
        
        if (value == 0)
        {
            currentScore = 0;
        }
        
        currentScore += value;
        scoreCount.text = currentScore.ToString();
        // Debug.Log(currentScore);
        
        
    }



}
