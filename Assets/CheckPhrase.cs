using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPhrase : MonoBehaviour
{
    public List<string> ExpectedWords;
    public GameObject WordsGroup;

    public void CheckWords()
    {
        var index = 0;
        foreach (Transform word in WordsGroup.transform)
        {
            var text = word.transform.GetChild(0).gameObject.GetComponent<Text>();
            if (ExpectedWords[index] == text.text)
                text.color = Color.green;
            else
                text.color = Color.red;
            index++;
        }
    }
}
