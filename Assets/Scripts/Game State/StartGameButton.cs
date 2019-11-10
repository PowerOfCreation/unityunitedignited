using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    public void OnClick()
    {
        GameManager.Instance.StartGame();
    }
}
