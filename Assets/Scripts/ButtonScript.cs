using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    [Header("Score")]
    public int currentScore;
    public TMP_Text scoreCount;
    public int minRandomScore = -999999999;
    public int maxRandomScore = 999999999;

    
    [Header("Key Image")]
    public Image keyImage;
    public Button hideButton;
    public Button showButton;


    [Header("Color sliders")]
    public Image rupeeImage;
    public Slider red;
    public Slider blue;
    public Slider green;
    public Slider alpha;




    private void Awake()
    {
        scoreCount.text = currentScore.ToString();
        
    }

    public void SliderEdit()
    {
        Color color = rupeeImage.color;
        
            
        float normalizedRed = red.value / red.maxValue;
        float normalizedGreen = green.value / green.maxValue;
        float normalizedBlue = blue.value / blue.maxValue;
        float normalizedAlpha = alpha.value / alpha.maxValue;

        color.r = normalizedRed;
        color.g = normalizedGreen;
        color.b = normalizedBlue;
        color.a = normalizedAlpha;
            

            rupeeImage.color = color;
            

            
        
    }



    public void hideKey()
    {
        keyImage.gameObject.SetActive(false);
        hideButton.gameObject.SetActive(false);
        showButton.gameObject.SetActive(true);
    }
    
    public void showKey()
    {
        keyImage.gameObject.SetActive(true);
        hideButton.gameObject.SetActive(true);
        showButton.gameObject.SetActive(false);
    }

    public void ScoreUpdater(int value)
    {

        if (value == 0)
        {
            currentScore = 0;
        }
        else
        {
            currentScore += value;

            if (currentScore < 0)
            {
                currentScore = 0; 
            }
            else if (currentScore > 999999999)
            {
                currentScore = 999999999; 
            }
        }

        scoreCount.text = currentScore.ToString("N0");
        // Debug.Log(currentScore);
    }


    public void RandomButton()
    {
        int randomScore = Random.Range(minRandomScore, maxRandomScore + 1);
        ScoreUpdater(randomScore);
    }
            
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Application closed");
    }

            








}
