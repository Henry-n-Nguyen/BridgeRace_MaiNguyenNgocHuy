using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : UICanvas
{
    public void RestartLevel()
    {
        GameplayManager.instance.RestartGame();
        UIManager.instance.InGame();
    }
}
