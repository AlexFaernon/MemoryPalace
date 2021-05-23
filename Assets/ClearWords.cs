using UnityEngine;
using UnityEngine.UI;

public class ClearWords : MonoBehaviour
{
    public GameObject WordsGroup;
    public void ClearWordsMethod()
    {
        foreach (Transform word in WordsGroup.transform)
        {
            var text = word.transform.GetChild(0).gameObject.GetComponent<Text>();
            text.text = "";
            text.color = Color.black;
        }
    }
}
