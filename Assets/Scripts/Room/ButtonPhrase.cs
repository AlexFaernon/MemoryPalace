using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPhrase : MonoBehaviour
{
    public GameObject WordGroups;
    public GameObject GroupToEnable;
    public GameObject Words;
    public Color StandartColor;
    public Color PressColor;
    public void OnClick()
    {
        foreach (Transform word in Words.transform)
        {
            word.GetChild(1).GetComponent<Image>().color = StandartColor;
        }

        gameObject.transform.GetChild(1).GetComponent<Image>().color = PressColor;
        foreach (Transform wordGroup in WordGroups.transform)
        {
            if (wordGroup.gameObject == GroupToEnable)
            {
                wordGroup.gameObject.SetActive(true);
                continue;
            }
            wordGroup.gameObject.SetActive(false);
        }
    }
}
