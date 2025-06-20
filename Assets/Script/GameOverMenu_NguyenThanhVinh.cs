using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu_NguyenThanhVinh : MonoBehaviour
{
    public GameObject gameOverUI;

    public void ShowGameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f; 
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
