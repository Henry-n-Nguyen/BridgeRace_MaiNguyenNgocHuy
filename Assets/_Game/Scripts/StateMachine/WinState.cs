using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HuySpace;

public class WinState : IState<Character>
{
    public void OnEnter(Character t)
    {

    }

    public void OnExecute(Character t)
    {
        t.EndLevel();
    }

    public void OnExit(Character t)
    {

    }

}
