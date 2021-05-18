using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPhrase : MonoBehaviour
{
    public List<string> ExpectedWords;
    public GameObject WordsGroup;
    public Sprite GoldenStar;
    public GameObject LeftStar;
    public GameObject RightStar;
    public GameObject CentralStar;
    public GameObject Screen;
    public GameObject ErrorText;
    public GameObject CheerPhrase;
    private int ErrorsCount;

    public void CheckWords()
    {
        var index = 0;
        var correctCount = 0;
        foreach (Transform word in WordsGroup.transform)
        {
            var text = word.transform.GetChild(0).gameObject.GetComponent<Text>();
            if (ExpectedWords[index] == text.text)
            {
                text.color = Color.green;
                correctCount++;
            }
            else
            {
                text.color = Color.red;
                ErrorsCount++;
            }
            index++;
        }
        //сделать кастомынй размер для каждой фразы
        if (correctCount == ExpectedWords.Count)
        {
            Screen.SetActive(true);
            var cheerText = CheerPhrase.GetComponent<Text>();
            if (ErrorsCount < 5)
            {
                LeftStar.GetComponent<Image>().sprite = GoldenStar;
            }

            if (ErrorsCount < 3)
            {
                RightStar.GetComponent<Image>().sprite = GoldenStar;
                cheerText.text = "Неплохо";
                cheerText.fontSize = 114;
            }

            if (ErrorsCount == 0)
            {
                CentralStar.GetComponent<Image>().sprite = GoldenStar;
                cheerText.text = "Молодец!";
                cheerText.fontSize = 114;
            }

            ErrorText.GetComponent<Text>().text = $"Ошибок: {ErrorsCount}";
        }
    }
}
