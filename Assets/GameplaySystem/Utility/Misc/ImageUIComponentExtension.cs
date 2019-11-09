using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ImageUIComponentExtension
{
    public static void SetSprite(this Image image, Sprite sprite)
    {
        image.sprite = sprite;

        if(sprite != null)
        {
            image.color = Color.white;
        }
        else
        {
            image.color = Color.clear;
        }
    }
}