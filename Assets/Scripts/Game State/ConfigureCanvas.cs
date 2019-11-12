using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigureCanvas : MonoBehaviour
{
    void Start()
    {
        GetComponent<CanvasGroup>().Hide();
        GameStateManager.Instance.GameOverCanvas = gameObject;
    }
}
