﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public void OnClick()
    {
        GameStateManager.Instance.RestartGame();
    }
}
