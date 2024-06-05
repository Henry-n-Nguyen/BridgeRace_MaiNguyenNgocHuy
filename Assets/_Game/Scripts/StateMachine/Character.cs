using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HuySpace;
using System.Drawing;
using UnityEngine.AI;

public abstract class Character : MonoBehaviour
{
    protected const string TRIGGER_RUN = "run";
    protected const string TRIGGER_IDLE = "idle";
    protected const string TRIGGER_NO_1 = "win1";
    protected const string TRIGGER_WIN = "win2";
    protected const string TAG_BRICK = "Brick";
    protected const string TAG_ENTRANCE = "Entrance";

    protected const string TAG_MAP_01 = "Map01";
    protected const string TAG_MAP_02 = "Map02";
    protected const string TAG_MAP_03 = "Map03";

    const float BRICK_HEIGHT = 0.25f;
    const float PLAYER_HEIGHT = 2f;

    // Editor
    [SerializeField] protected Transform playerTransform;
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] private Animator anim;
    [SerializeField] private Transform playerBrickHolder;
    [SerializeField] private LayerMask bridgeLayer;

    [SerializeField] private Brick brickPrefab;

    public bool isMoving;
    public bool isEnterEntrance;

    [SerializeField] ColorData colorData;
    [SerializeField] Renderer meshRenderer;
    
    public int rank;

    public ColorType color;

    public bool isGrounded;

    protected float moveSpeed = 8f;

    public int currentMap = 1;

    // Private
    private IState<Character> currentState;

    private string currentAnimName;

    protected Stack<GameUnit> bricks = new Stack<GameUnit>();

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

        if (!isMoving)
        {
            rb.isKinematic = true;
        }
        else
        {
            rb.isKinematic= false;
        }
    }

    public bool IsRanOutOfBrick()
    {
        return bricks.Count <= 0;
    }

    public virtual void OnInit()
    {
        ClearBrick();

        agent.speed = moveSpeed;

        currentMap = 1;

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

    protected void ChangeAnim(string animName)
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

    public virtual void BuildBridge()
    {
        ChangeAnim(TRIGGER_RUN);
    }

    public virtual void EndLevel()
    {
        if (rank == 1) ChangeAnim(TRIGGER_NO_1);
        else ChangeAnim(TRIGGER_WIN);
    }

    public virtual bool OnDownStair()
    {
        if (Physics.Raycast(playerTransform.position, Vector3.down, out RaycastHit slopeHit, Mathf.Abs(PLAYER_HEIGHT * 0.5f + 0.3f), bridgeLayer))
        {
            float angle = 90f - Vector3.Angle(playerTransform.forward, slopeHit.normal);

            return angle >= 0f;
        }

        return false;
    }

    public virtual void AddBrick()
    {
        Vector3 pos = Vector3.up * BRICK_HEIGHT * bricks.Count;

        Brick createdObj = Instantiate(brickPrefab, playerBrickHolder);

        createdObj.ChangeColor(color);

        createdObj.brickTransform.localPosition = pos;

        bricks.Push(createdObj);
    }

    public virtual void RemoveBrick()
    {
        Destroy(bricks.Pop().gameObject);
    }

    public virtual void ClearBrick()
    {
        foreach (Brick brick in bricks) Destroy(brick.gameObject);
        bricks.Clear();
    }

    public void ChangeColor(ColorType colorType)
    {
        color = colorType;
        meshRenderer.material = colorData.GetMat(colorType);
    }

    public void WarpTo(Vector3 pos)
    {
        agent.Warp(pos);
    }
}
