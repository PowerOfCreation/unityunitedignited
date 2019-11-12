using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigSceneStartGame : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        GameManager.Instance.StartGame();
    }
}
