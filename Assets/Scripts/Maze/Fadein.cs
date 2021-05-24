using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fadein : MonoBehaviour
{
    private Image fadeoutImage;
    void Awake()
    {
        fadeoutImage = GetComponent<Image>();
    }

    void Update()
    {
        var colours = fadeoutImage.color;
        if (colours.a != 0)
        {
            fadeoutImage.color = new Color(colours.r, colours.g, colours.b, colours.a - 0.5f * Time.deltaTime);
        }
    }
}