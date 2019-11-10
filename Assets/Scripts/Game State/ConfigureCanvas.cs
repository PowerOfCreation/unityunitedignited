using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigureCanvas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CanvasGroup>().Hide();
        GameStateManager.Instance.GameOverCanvas = gameObject;
    }
}
