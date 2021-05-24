using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Fadeout : MonoBehaviour
{
    private Image fadeoutImage;
    void Awake()
    {
        fadeoutImage = GetComponent<Image>();
    }

    void Update()
    {
        var colours = fadeoutImage.color;
        if (Math.Abs(colours.a - 1) > 0.05F)
        {
            fadeoutImage.color = new Color(colours.r, colours.g, colours.b, colours.a + 0.5f * Time.deltaTime);
        }
    }
}
