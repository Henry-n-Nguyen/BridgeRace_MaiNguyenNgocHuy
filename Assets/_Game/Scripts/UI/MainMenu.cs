using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : UICanvas
{
    public void TapToStart()
    {
        GameplayManager.instance.StartGame();

        Close(0);
        UIManager.instance.OpenUI<DynamicJoyStick>();
        UIManager.instance.OpenUI<InGame>();
    }
}
