using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static void ChangeToMaze()
    {
        SceneManager.LoadScene("maze");
    }
}
