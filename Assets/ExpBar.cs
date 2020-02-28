using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{

    public Slider slider;
    public void SetZeroExp (int score)
    {
        slider.minValue = score;
        
    }

    public void SetExp (int score)
    {
        slider.value = score;
    }

}
