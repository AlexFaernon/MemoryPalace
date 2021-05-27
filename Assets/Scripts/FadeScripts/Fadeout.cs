using System;
using UnityEngine;
using UnityEngine.UI;

public class Fadeout : MonoBehaviour
{
    private Image fadeoutImage;
    void Awake()
    {
        fadeoutImage = GetComponent<Image>();
    }

    private void OnEnable()
    {
        var colours = fadeoutImage.color;
        fadeoutImage.color = new Color(colours.r, colours.g, colours.b, 0);
    }

    void Update()
    {
        var colours = fadeoutImage.color;
        fadeoutImage.color = new Color(colours.r, colours.g, colours.b, colours.a + 0.5f * Time.deltaTime);
    }
}