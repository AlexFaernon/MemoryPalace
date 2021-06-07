using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    public List<GameObject> toEnable;
    public GameObject Tutorial;
    public GameObject FadeoutObj;
    public GameObject FadeinObj;

    public void OnClick()
    {
        gameObject.GetComponent<Button>().interactable = false;
        StartCoroutine(ChangeToMaze());
    }
    private IEnumerator ChangeToMaze()
    {
        FadeoutObj.SetActive(true);
        yield return new WaitForSeconds(2);
        Tutorial.SetActive(false);
        foreach (var gameObject in toEnable)
        {
            gameObject.SetActive(true);
        }
        SceneManager.LoadScene("maze", LoadSceneMode.Additive);
        yield return new WaitWhile(() => !SceneManager.GetSceneByName("maze").isLoaded);
        yield return new WaitWhile(() => SceneManager.GetSceneByName("maze").isLoaded);
        gameObject.GetComponent<Button>().interactable = true;
        FadeinObj.SetActive(true);
        FadeoutObj.SetActive(false);
        yield return new WaitForSeconds(2);
        FadeinObj.SetActive(false);
    }
}