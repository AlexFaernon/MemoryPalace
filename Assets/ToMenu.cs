using UnityEngine.SceneManagement;
using UnityEngine;

public class ToMenu : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
