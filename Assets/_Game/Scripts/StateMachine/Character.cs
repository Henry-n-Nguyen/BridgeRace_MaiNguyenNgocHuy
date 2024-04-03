using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    const string TRIGGER_RUN = "run";
    const string TRIGGER_IDLE = "idle";

    [SerializeField] private Animator anim;

    private IState<Character> currentState;

    private string currentAnimName;

    private void Start()
    {
        ChangeState(new IdleState());
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }

    public void ChangeState(IState<Character> state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }

    public void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            currentAnimName = animName;
            anim.ResetTrigger(animName);
            anim.SetTrigger(currentAnimName);
        }
    }

    public void Moving()
    {
        ChangeAnim(TRIGGER_RUN);
    }

    public void StopMoving()
    {
        ChangeAnim(TRIGGER_IDLE);
    }
}
