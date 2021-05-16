using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeWord : MonoBehaviour
{
    public GameObject ButtonToChange;

    public void OnClick()
    {
        var textToChange = ButtonToChange.transform.GetChild(0).gameObject;
        var text = transform.GetChild(0).gameObject;
        textToChange.GetComponent<Text>().text = text.GetComponent<Text>().text;
    }
}
