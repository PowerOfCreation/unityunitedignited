using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CanvasGroupExtension
{
    public static void Hide(this CanvasGroup canvasGroup, bool hideChilds = true)
    {
        canvasGroup.alpha = 0f;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;

        if (hideChilds)
        {
            foreach (CanvasGroup child in canvasGroup.GetComponentsInChildren<CanvasGroup>()) { child.Hide(false); }
        }
    }

    public static void Show(this CanvasGroup canvasGroup, bool showChilds = true)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;

        if (showChilds)
        {
            foreach (CanvasGroup child in canvasGroup.GetComponentsInChildren<CanvasGroup>()) { child.Show(false); }
        }
    }
}