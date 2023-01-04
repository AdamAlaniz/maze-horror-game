using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject MainMenuPanel;
    [SerializeField] private GameObject IntroPanel;
    [SerializeField] private GameObject ControlsPanel;

    private void Start()
    {
        Time.timeScale = 1;
        MainMenuPanel.SetActive(true);
        IntroPanel.SetActive(false);
        ControlsPanel.SetActive(false);
    }

    public void EasyPlay()
    {
        //SET EASY PLAYER PREFERENCE
        PlayerPrefs.SetInt("Difficulty", 0);
        MainMenuPanel.SetActive(false);
        IntroPanel.SetActive(true);
    }

    public void HardPlay()
    {
        //SET HARD PLAYER PREFERENCE
        PlayerPrefs.SetInt("Difficulty", 1);
        MainMenuPanel.SetActive(false);
        IntroPanel.SetActive(true);
    }

    public void ControlMenu()
    {
        MainMenuPanel.SetActive(false);
        ControlsPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Game Over");
        PlayerPrefs.DeleteKey("Difficulty");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void WakeUp()
    {
        IntroPanel.SetActive(false);
        GameObject.FindGameObjectWithTag("Speaker").GetComponent<Music>().playSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void BackToMenu()
    {
        ControlsPanel.SetActive(false);
        MainMenuPanel.SetActive(true);
    }
}
