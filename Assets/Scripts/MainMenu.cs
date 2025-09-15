using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Scene"); 
    }

    public void QuitGame()
    {
        Debug.Log("Выход из игры"); 
        Application.Quit();
    }
}
