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

    [Header("Progress Bar")]
    public Slider progress;
    public TMP_Text percentageText;


    [Header("Radial Cooldown")]
    public Image cooldownImage; 
    public float cooldownTime = 3f; 
    private bool isCooldown = false;

    private void Awake()
    {
        
        scoreCount.text = currentScore.ToString();
        cooldownImage.gameObject.SetActive(false);

    }

    // activates when button is pressed next to cooldown
    public void OnCooldownButtonPress()
    {
        if (!isCooldown) 
        {
            cooldownImage.gameObject.SetActive(true);
            StartCooldown();

        }
    }

    // starts cooldown
    private void StartCooldown()
    {
        isCooldown = true; 
        cooldownImage.fillAmount = 1f; 

        
        InvokeRepeating("ReduceFillAmount", 0f, cooldownTime / 100);
    }

    // gradually reduces fill amount
    private void ReduceFillAmount()
    {
        cooldownImage.fillAmount -= Time.deltaTime / cooldownTime; 

        
        if (cooldownImage.fillAmount <= 0)
        {
            cooldownImage.fillAmount = 0f; 
            cooldownImage.gameObject.SetActive(false); 
            isCooldown = false; 
            CancelInvoke("ReduceFillAmount"); 
        }
    }

    // edit color slider
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

            
        


    // progress bar
    public void ChangeProgressBar(float value)
    {
        progress.value += value;
        UpdatePercentageText();
    }

    public void UpdatePercentageText()
    {
        float percentage = (progress.value / progress.maxValue) * 100f;
        percentageText.text = $"Progress: {percentage:F2}%";
    }


    // hide/show image
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

    
    // update score
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

    // random value for score
    public void RandomButton()
    {
        int randomScore = Random.Range(minRandomScore, maxRandomScore + 1);
        ScoreUpdater(randomScore);
    }
            
    
    
    // Exit game
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Application closed");
    }

            








}
