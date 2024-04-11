using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : UICanvas
{
    public void TapToStart()
    {
        GameplayManager.instance.StartGame();
        UIManager.instance.InGame();
    }
}
