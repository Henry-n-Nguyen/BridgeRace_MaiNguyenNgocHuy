using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovingByNavMeshAgent : Character
{
    [SerializeField] private Vector3 desPoint;

    [SerializeField] private Vector3 endPoint;
    [SerializeField] private Vector3 entrancePoint;

    [SerializeField] private LayerMask brickLayer;
    [SerializeField] private LayerMask stepLayer;
    [SerializeField] private LayerMask entranceLayer;

    private bool isDetected;
    private bool entranceDetected;
    
    private NavMeshPath path;

    public override void Moving()
    {
        base.Moving();

        if (!isMoving)
        {
            isDetected = false;
            ChangeState(new IdleState());
        }

        if (bricks.Count >= 20)
        {
            isDetected = false;
            ChangeState(new BuildState());
        }

        if (!isDetected)
        {
            FindBrick();
            isDetected = true;
        }

        agent.SetDestination(desPoint);
    }

    public override void StopMoving()
    {
        base.StopMoving();

        if (isMoving)
        {
            isDetected = false;
            ChangeState(new PatrolState());
        }
    }

    public override void BuildBridge()
    {
        base.BuildBridge();

        if (!isMoving)
        {
            isDetected = false;
            ChangeState(new IdleState());
        }

        if (isEnterEntrance)
        {
            isDetected = false;
            currentMap++;
            FindBrick();
            ChangeState(new PatrolState());
            entranceDetected = false;
            isEnterEntrance = false;
        }

        if (IsRanOutOfBrick())
        {
            isDetected = false;
            ChangeState(new PatrolState());
        }

        if (!isDetected)
        {
            FindNextMap();
            isDetected = true;
            agent.SetDestination(entrancePoint);
        }

    }

    public override void AddBrick()
    {
        base.AddBrick();

        isDetected = false;
    }

    private void FindBrick()
    {
        bool detect = false;

        foreach (GameUnit unit in Platform.instance.bricks)
        {
            if (unit.colorType == color)
            {
                desPoint = unit.transform.position;
                detect = true;
                break;
            }
        }

        if (!detect)
        {
            isDetected = false;
        }
    }

    private void FindNextMap()
    {
        bool detect = false;

        if (!entranceDetected)
        {
            Collider[] objectInRange = Physics.OverlapSphere(playerTransform.position, 200f, entranceLayer);

            if (objectInRange.Length > 0)
            {
                entrancePoint = objectInRange[Random.Range(0, objectInRange.Length)].transform.position;
                detect = true;
                entranceDetected = true;
            }
        }
        else
        {
            detect = true;
        }

        if (!detect)
        {
            isDetected = false;
        }
    }

    private bool CheckTag(int currentMapIndex, Collider collider) 
    {
        switch (currentMapIndex)
        {
            case 1: return collider.CompareTag(TAG_MAP_01);
            case 2: return collider.CompareTag(TAG_MAP_02);
            case 3: return collider.CompareTag(TAG_MAP_03);
            default: return false;
        }
    }
}
