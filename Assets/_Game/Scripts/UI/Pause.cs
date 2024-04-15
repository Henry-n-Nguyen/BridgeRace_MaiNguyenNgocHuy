using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : UICanvas
{
    public void Resume()
    {
        GameplayManager.instance.ResumeGame();
        UIManager.instance.InGame();
    }

    public void Restart()
    {
        GameplayManager.instance.ResumeGame();
        GameplayManager.instance.RestartGame();
        UIManager.instance.InGame();
    }

    public void MainMenu()
    {
        GameplayManager.instance.ResumeGame();
        GameplayManager.instance.RestartGame();
        UIManager.instance.OpenMainMenu();
    }
}
