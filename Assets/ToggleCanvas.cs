using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleCanvas : MonoBehaviour
{
    private bool isShown = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CanvasGroup>().Hide();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Escape"))
        {
            if (!isShown)
            {
                GetComponent<CanvasGroup>().Show();
                isShown = true;
            }
            else
            {
                GetComponent<CanvasGroup>().Hide();
                isShown = false;
            }
        }
    }
}
