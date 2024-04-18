using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : UICanvas
{
    public void NextLevel()
    {
        LevelManager.instance.ResetLevel();

        Close(0);
        UIManager.instance.OpenUI<DynamicJoyStick>();
        UIManager.instance.OpenUI<InGame>();
    }
}
