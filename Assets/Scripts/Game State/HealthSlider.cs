using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    public static HealthSlider self;
    
    [HideInInspector]
    public Slider slider;
    
    void Start()
    {
        self = this;
        slider = GetComponent<Slider>();
    }
}
