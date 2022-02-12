using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthMenu : MonoBehaviour
{
  public Slider slider;
    public bool isSlider;
   

    private void Awake()
    {
        slider.maxValue = 100;
        slider.minValue = 0;
        slider.value = 100;
    }
    public void DecreaseHealth()
    {
        if (isSlider)
        {
            slider.value -= 25;
         
        }
    }
}
