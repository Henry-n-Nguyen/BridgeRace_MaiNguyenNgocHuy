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
    [SerializeField] UICanvas loadingUI;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(Loading());
    }

    public void OpenMainMenu()
    {
        CloseAll();
        mainMenuUI.Open();
        GameplayManager.instance.PauseGame();
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

    public IEnumerator Loading()
    {
        CloseAll();
        loadingUI.Open();
        yield return new WaitForSeconds(5f);
        OpenMainMenu();
    }

    private void CloseAll()
    {
        mainMenuUI.Close();
        winUI.Close();
        loseUI.Close();
        pauseUI.Close();
        inGameUI.Close();
        joyStickUI.Close();
        loadingUI.Close();
    }
}
