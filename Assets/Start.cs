using UnityEngine.SceneManagement;
using UnityEngine;

public class Start : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("room");
    }
}
