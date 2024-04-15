using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : UICanvas
{
    public void NextLevel()
    {
        GameplayManager.instance.RestartGame();

        Close(0);
        UIManager.instance.OpenUI<DynamicJoyStick>();
        UIManager.instance.OpenUI<InGame>();
    }
}
