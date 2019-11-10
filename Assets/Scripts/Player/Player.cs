using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player self;

    void Start()
    {
        self = this;
        GameManager.Instance.SetLocalPlayer(transform);
    }
}
