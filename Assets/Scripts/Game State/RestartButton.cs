using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public void OnClick()
    {
        GameManager.Instance.StartGame();
        GameStateManager.Instance.GameOverCanvas.GetComponent<CanvasGroup>().Hide();
        PlayerHealth.self.ResetHealth();
    }
}
