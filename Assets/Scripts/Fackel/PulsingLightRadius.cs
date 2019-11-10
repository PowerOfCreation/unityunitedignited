using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class PulsingLightRadius : MonoBehaviour
{
    private Light _light;
    private float startRadius;
    
    [SerializeField]
    private float pulsingSpeed = 2f;
    [SerializeField]
    private float pulsingRange = .2f;
    
    private void Start()
    {
        _light = GetComponent<Light>();
        startRadius = _light.range;
    }

    private void FixedUpdate()
    {
        float sinTime = Mathf.Abs(Mathf.Sin(Time.fixedTime * pulsingSpeed));
        _light.range = this.startRadius + sinTime * pulsingRange;
    }
}
