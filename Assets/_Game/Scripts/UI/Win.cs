using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : UICanvas
{
    public void NextLevel()
    {
        GameplayManager.instance.RestartGame();
        UIManager.instance.InGame();
    }
}
