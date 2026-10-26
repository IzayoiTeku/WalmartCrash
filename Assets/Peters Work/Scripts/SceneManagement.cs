using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SceneManagement : MonoBehaviour
{
    public GameObject MainObject;
    public GameObject HTPObject;
    public GameObject CreditsObject;
    public GameObject PauseObject;
    public GameObject WinObject;
    public GameObject LoseObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MainObject.SetActive(true);
        HTPObject.SetActive(false);
        CreditsObject.SetActive(false);
        PauseObject.SetActive(false);
        WinObject.SetActive(false);
        LoseObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            MainObject.SetActive(true);
            PauseObject.SetActive(false);
            HTPObject.SetActive(false);
            CreditsObject.SetActive(false);
            WinObject.SetActive(false);
            LoseObject.SetActive(false);
        }
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GameScene()
    {
        SceneManager.LoadScene("TestScene");
    }
    public void CreditsScene()
    {
        CreditsObject.SetActive(true);
        MainObject.SetActive(false);
        PauseObject.SetActive(false);
        HTPObject.SetActive(false);
        WinObject.SetActive(false);
        LoseObject.SetActive(false);
    }
    public void HowToPlayScene()
    {
        HTPObject.SetActive(true);
        CreditsObject.SetActive(false);
        MainObject.SetActive(false);
        PauseObject.SetActive(false);
        WinObject.SetActive(false);
        LoseObject.SetActive(false);
    }
    public void ExitGame() 
    {
        Application.Quit();
    }
    public void WinGame()
    {
        WinObject.SetActive(true);
        CreditsObject.SetActive(false);
        MainObject.SetActive(false);
        PauseObject.SetActive(false);
        HTPObject.SetActive(false);
        LoseObject.SetActive(false);
    }
    public void LoseGame()
    {
        LoseObject.SetActive(true);
        WinObject.SetActive(false);
        CreditsObject.SetActive(false);
        MainObject.SetActive(false);
        PauseObject.SetActive(false);
        HTPObject.SetActive(false);
    }
}
