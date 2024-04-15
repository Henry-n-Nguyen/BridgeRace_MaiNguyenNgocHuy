using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame : UICanvas
{
    public void PauseGame()
    {
        GameplayManager.instance.PauseGame();

        Close(0);
        UIManager.instance.CloseDirectly<DynamicJoyStick>();
        UIManager.instance.OpenUI<Pause>();
    }
}
