using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HuySpace;
using System.Drawing;

public abstract class Character : MonoBehaviour
{
    const string TRIGGER_RUN = "run";
    const string TRIGGER_IDLE = "idle";

    const float BRICK_HEIGHT = 0.25f;

    [SerializeField] private Animator anim;
    [SerializeField] private Transform playerBrickHolder;

    [SerializeField] private GameObject brickPrefab;

    [SerializeField] ColorData colorData;
    [SerializeField] Renderer meshRenderer;
    public ColorType color;

    private IState<Character> currentState;

    private string currentAnimName;

    private Stack<GameObject> bricks = new Stack<GameObject>();

    private void Start()
    {
        OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }

    public virtual void OnInit()
    {
        ChangeState(new IdleState());
        ChangeColor(ColorType.Red);
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

    public virtual void Moving()
    {
        ChangeAnim(TRIGGER_RUN);
    }

    public virtual void StopMoving()
    {
        ChangeAnim(TRIGGER_IDLE);
    }

    public void AddBrick()
    {
        Vector3 pos = playerBrickHolder.position + Vector3.up * BRICK_HEIGHT * bricks.Count;
        GameObject createdObj = Instantiate(brickPrefab, pos, brickPrefab.transform.rotation, playerBrickHolder);

        bricks.Push(createdObj);
    }

    public void ChangeColor(ColorType colorType)
    {
        color = colorType;
        meshRenderer.material = colorData.GetMat(colorType);
    }
}
