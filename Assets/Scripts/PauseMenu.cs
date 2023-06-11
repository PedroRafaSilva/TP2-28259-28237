using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;

    void Start()
    {
        ShowPauseMenu(false);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            ShowPauseMenu(true);
        }
        else
        {
            Time.timeScale = 1f;
            ShowPauseMenu(false);
        }
    }

    public void ShowPauseMenu(bool show)
    {
        pauseMenuUI.SetActive(show);
    }

    public void Resume()
    {
        TogglePause();
    }

    public void Restart()
    {
        TogglePause();
        SceneManager.LoadScene("PlayerScene");
    }

    public void QuitGame()
    {
        TogglePause();
        SceneManager.LoadScene("Menu");
    }
}
