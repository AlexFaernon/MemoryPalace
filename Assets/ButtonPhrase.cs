using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPhrase : MonoBehaviour
{
    public GameObject WordGroups;
    public GameObject GroupToEnable;
    public void OnClick()
    {
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
