using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private GameObject GamePanel;
    [SerializeField] private GameObject GameOverWinPanel;
    [SerializeField] private GameObject GameOverLosePanel;

    public void GameOverWin()
    {
        Cursor.lockState = CursorLockMode.None;
        GameObject.FindGameObjectWithTag("Speaker").GetComponent<Music>().playSound();
        Time.timeScale = 0;
        GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPOVPlayerController>().enabled = false;
        GameOverWinPanel.SetActive(true);
    }

    public void GameOverLose()
    {
        Cursor.lockState = CursorLockMode.None;
        GameObject.FindGameObjectWithTag("Speaker").GetComponent<Music>().playSound();
        Time.timeScale = 0;
        GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPOVPlayerController>().enabled = false;
        GameOverLosePanel.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
