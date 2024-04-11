using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] UICanvas inGameUI;
    [SerializeField] UICanvas joyStickUI;

    [SerializeField] UICanvas mainMenuUI;
    [SerializeField] UICanvas winUI;
    [SerializeField] UICanvas loseUI;
    [SerializeField] UICanvas pauseUI;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        OpenMainMenu();
    }

    public void OpenMainMenu()
    {
        CloseAll();
        mainMenuUI.Open();
    }

    public void InGame()
    {
        CloseAll();
        inGameUI.Open();
        joyStickUI.Open();
    }

    public void Win()
    {
        CloseAll();
        winUI.Open();
    }
    
    public void Lose()
    {
        CloseAll();
        loseUI.Open();
    }

    public void Pause()
    {
        CloseAll();
        pauseUI.Open();
    }

    private void CloseAll()
    {
        mainMenuUI.Close();
        winUI.Close();
        loseUI.Close();
        pauseUI.Close();
        inGameUI.Close();
        joyStickUI.Close();
    }
}
