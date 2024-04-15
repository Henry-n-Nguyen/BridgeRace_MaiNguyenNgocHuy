using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : UICanvas
{
    public void Resume()
    {
        GameplayManager.instance.ResumeGame();

        Close(0);
        UIManager.instance.OpenUI<DynamicJoyStick>();
        UIManager.instance.OpenUI<InGame>();
    }

    public void Restart()
    {
        GameplayManager.instance.ResumeGame();
        GameplayManager.instance.RestartGame();

        Close(0);
        UIManager.instance.OpenUI<DynamicJoyStick>();
        UIManager.instance.OpenUI<InGame>();
    }

    public void MainMenu()
    {
        GameplayManager.instance.RestartGame();
        GameplayManager.instance.OnHold();

        Close(0);
        UIManager.instance.OpenUI<MainMenu>();
    }
}
