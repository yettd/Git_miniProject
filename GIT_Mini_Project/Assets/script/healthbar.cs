using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public void sliderhealth(float health)
    {
        slider.value = health;
    }
    public void maxhealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
}
