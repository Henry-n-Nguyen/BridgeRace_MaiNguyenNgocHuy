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
    }

    public void OnInit()
    {
        levelManager.gameObject.SetActive(true);
    }

    public void StartGame()
    {
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

    public void RestartGame()
    {
        LevelManager.instance.ResetLevel();
    } 
}
