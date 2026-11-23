using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject PauseObject;
    public GameObject WinObject;
    public GameObject LoseObject;
    public static bool Paused = false;
    private bool GameEnded = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PauseObject.SetActive(false);
        WinObject.SetActive(false);
        LoseObject.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        GameEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameEnded)
        {
            return;
        }
        if(Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if(Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        if(GameEnded)
        {
            return;
        }
        PauseObject.SetActive(true);
        Time.timeScale = 0f;
        Paused  = true;
    }
    public void Resume()
    {
        if(GameEnded)
        {
            return;
        }
        PauseObject.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }
    public void Win()
    {
        if(GameEnded)
        {
            return;
        }
        GameEnded = true;
        WinObject.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }
    public void Lose()
    {
        if(GameEnded)
        {
            return;
        }
        GameEnded = true;
        LoseObject.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
