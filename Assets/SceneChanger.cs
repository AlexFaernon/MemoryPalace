using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public List<GameObject> toEnable;
    public void ChangeToMaze()
    {
        foreach (var gameObject in toEnable)
        {
            gameObject.SetActive(true);
        }
        SceneManager.LoadScene("maze", LoadSceneMode.Additive);
    }
}