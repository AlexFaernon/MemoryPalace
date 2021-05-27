using System;
using UnityEngine;
using UnityEngine.UI;

public class Fadein : MonoBehaviour
{
    private Image fadeinImage;
    void Awake()
    {
        fadeinImage = GetComponent<Image>();
    }

    private void OnEnable()
    {
        var colours = fadeinImage.color;
        fadeinImage.color = new Color(colours.r, colours.g, colours.b, 1);
    }

    void Update()
    {
        var colours = fadeinImage.color;
        fadeinImage.color = new Color(colours.r, colours.g, colours.b, colours.a - 0.5f * Time.deltaTime);
    }
}