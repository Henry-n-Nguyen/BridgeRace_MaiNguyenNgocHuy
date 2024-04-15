using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildState : IState<Character>
{
    public void OnEnter(Character t)
    {

    }

    public void OnExecute(Character t)
    {
        t.BuildBridge();
    }

    public void OnExit(Character t)
    {

    }
}
