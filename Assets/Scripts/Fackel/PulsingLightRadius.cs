using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class PulsingLightRadius : MonoBehaviour
{
    private Light _light;
    private float startRadius;

    private void Start()
    {
        _light = GetComponent<Light>();
        startRadius = _light.range;
    }

    private void FixedUpdate()
    {
        float sinTime = Mathf.Sin(Time.fixedTime * 3f);
        _light.range = this.startRadius + sinTime * 0.2f;
    }
}
