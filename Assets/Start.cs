using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Start : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("room");
    }
}
