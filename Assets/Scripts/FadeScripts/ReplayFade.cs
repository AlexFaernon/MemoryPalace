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

    public void OnClick()
    {
        StartCoroutine(Replay());
    }

    private IEnumerator Replay()
    {
        FadeoutObj.SetActive(true);
        yield return new WaitForSeconds(2);
        foreach (var gameObject in ToDeactivate)
        {
            gameObject.SetActive(false);
        }
        foreach (Transform word in WordsGroup.transform)
        {
            var text = word.transform.GetChild(0).gameObject.GetComponent<Text>();
            text.text = "";
            text.color = Color.black;
        }
        FadeinObj.SetActive(true);
        FadeoutObj.SetActive(false);
        yield return new WaitForSeconds(2);
        FadeinObj.SetActive(false);
    }
}
