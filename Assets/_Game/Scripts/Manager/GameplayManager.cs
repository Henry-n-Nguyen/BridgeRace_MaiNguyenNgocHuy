using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;

    [SerializeField] private LevelManager levelManager;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        OnInit();
        OnHold();
    }

    public void OnInit()
    {
        levelManager.gameObject.SetActive(true);
        UIManager.instance.OpenUI<MainMenu>();
        UIManager.instance.OpenUI<LoadingUI>();
    }

    public void OnHold()
    {
        Platform.instance.DeactiveCharacter();
    }

    public void StartGame()
    {
        ResumeGame();
        StartCoroutine(ActiveCharacter());
    }

    private IEnumerator ActiveCharacter()
    {
        yield return new WaitForSeconds(1f);
        Platform.instance.ActiveCharacter();
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
    }
}
