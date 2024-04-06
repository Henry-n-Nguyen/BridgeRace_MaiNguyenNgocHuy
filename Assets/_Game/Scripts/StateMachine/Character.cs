using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HuySpace;
using System.Drawing;

public abstract class Character : MonoBehaviour
{
    protected const string TRIGGER_RUN = "run";
    protected const string TRIGGER_IDLE = "idle";
    protected const string TAG_BRICK = "Brick";

    const float BRICK_HEIGHT = 0.25f;

    [SerializeField] protected Transform playerTransform;
    [SerializeField] private Animator anim;
    [SerializeField] private Transform playerBrickHolder;

    [SerializeField] private Brick brickPrefab;

    [SerializeField] ColorData colorData;
    [SerializeField] Renderer meshRenderer;
    public ColorType color;

    private IState<Character> currentState;

    private string currentAnimName;

    private Stack<GameUnit> bricks = new Stack<GameUnit>();

    private void Start()
    {
        OnInit();
        ChangeColor(color);
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

    public virtual void AddBrick()
    {
        Vector3 pos = playerBrickHolder.position + Vector3.up * BRICK_HEIGHT * bricks.Count;

        Vector3 direction = transform.rotation.eulerAngles + Vector3.up * 90f;

        Brick createdObj = Instantiate(brickPrefab, pos, Quaternion.Euler(direction), playerBrickHolder);

        createdObj.ChangeColor(color);

        bricks.Push(createdObj);
    }

    public void ChangeColor(ColorType colorType)
    {
        color = colorType;
        meshRenderer.material = colorData.GetMat(colorType);
    }
}
