﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    public static HealthSlider self;

    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        self = this;
        slider = GetComponent<Slider>();
    }
}
