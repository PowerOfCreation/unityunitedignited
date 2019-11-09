using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAndFade : MonoBehaviour
{
    public Vector2 direction;
    public float speed = 1f;
    public float maxDeltaY = 4f;
    public float curDeltaY = 0f;

    public float exponent = -3f;
    public float exponentFunctionOffset = 0.5f;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        direction = direction.normalized;
    }

    void Update()
    {
        float deltaY = (speed * Time.deltaTime) + speed * Time.deltaTime * Mathf.Pow(exponentFunctionOffset + ((curDeltaY / maxDeltaY)), exponent);
        rectTransform.anchoredPosition += deltaY * direction;

        curDeltaY += deltaY;

        canvasGroup.alpha = (1 - (curDeltaY / maxDeltaY));

        if (curDeltaY >= maxDeltaY)
        {
            Destroy(gameObject);
        }
    }
}