using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject GamePanel;
    [SerializeField] private GameObject PauseMenuPanel;
    [SerializeField] private GameObject ControlsPanel;

    public static bool isPaused = false;


    // Start is called before the first frame update
    void Start()
    {
        GamePanel.SetActive(true);
        PauseMenuPanel.SetActive(false);
        ControlsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPOVPlayerController>().enabled = false;
        isPaused = true;
        PauseMenuPanel.SetActive(true);
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        isPaused = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPOVPlayerController>().enabled = true;
        PauseMenuPanel.SetActive(false);
        ControlsPanel.SetActive(false);
    }

    public void OpenControls()
    {
        PauseMenuPanel.SetActive(false);
        ControlsPanel.SetActive(true);
    }

    public void BackToPauseMenu()
    {
        ControlsPanel.SetActive(false);
        PauseMenuPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
