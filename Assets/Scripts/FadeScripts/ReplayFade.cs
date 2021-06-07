using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReplayFade : MonoBehaviour
{
    public GameObject FadeoutObj;
    public GameObject FadeinObj;
    public GameObject WordsGroup;
    public List<GameObject> ToDeactivate;
    public Color StandartColor;
    public GameObject SelectPhrase;

    public void OnClick()
    {
        StartCoroutine(Replay());
    }

    private IEnumerator Replay()
    {
        FadeoutObj.SetActive(true);
        yield return new WaitForSeconds(2);
        SelectPhrase.SetActive(true);
        foreach (var gameObject in ToDeactivate)
        {
            gameObject.SetActive(false);
        }
        foreach (Transform word in WordsGroup.transform)
        {
            var text = word.GetChild(0).GetComponent<Text>();
            var line = word.GetChild(1).GetComponent<Image>();
            text.text = "";
            text.color = Color.black;
            line.color = StandartColor;
        }
        FadeinObj.SetActive(true);
        FadeoutObj.SetActive(false);
        yield return new WaitForSeconds(2);
        FadeinObj.SetActive(false);
    }
}
