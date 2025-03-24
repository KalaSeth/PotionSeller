using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(3);
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene(3);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void DiscordFeedback()
    {
        Application.OpenURL("https://discord.gg/juYfSyGpZ8");
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}
