using UnityEngine.SceneManagement;
using UnityEngine;

public class MazeMenu : MonoBehaviour
{
    public GameObject Menu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !Menu.activeSelf)
        {
            Menu.SetActive(true);
        }
        else if (Menu.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.N) || Input.GetKeyDown(KeyCode.Escape))
            {
                Menu.SetActive(false);
            }
            else if (Input.GetKeyDown(KeyCode.Y))
            {
                Cursor.lockState = CursorLockMode.None;
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
