using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProgressBar : MonoBehaviour
{
    private Slider slider;
    
    

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }


    // Start is called before the first frame update
    void Start()
    {
        AddProgress(0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AddProgress(float newProgress)
    {
        slider.value += newProgress;
    }

}
