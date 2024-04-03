using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HuySpace;

public class IdleState : IState<Character>
{
    public void OnEnter(Character t)
    {

    }

    public void OnExecute(Character t)
    {
        if (DynamicJoyStick.instance.IsPressed) t.ChangeState(new PatrolState());
        t.StopMoving();
    }

    public void OnExit(Character t)
    {

    }

}
