using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using HuySpace;

public class MovingByNavMeshAgent : Character
{
    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private bool isMoving;
    [SerializeField] private bool isDetected;

    [SerializeField] private Vector3 desPoint;

    public override void Moving()
    {
        base.Moving();

        if (!isMoving)
        {
            isDetected = true;
            ChangeState(new IdleState());
        }

        if (!isDetected)
        {
            FindDestinationPoint();
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

    public override void AddBrick()
    {
        base.AddBrick();

        isDetected = false;
    }

    private void FindDestinationPoint()
    {
        int detect = 0;

        Collider[] objectInRange = Physics.OverlapSphere(playerTransform.position, 50f);

        foreach (Collider collider in objectInRange)
        {
            if (collider.gameObject.CompareTag(TAG_BRICK))
            {
                if (collider.GetComponent<GameUnit>().colorType == color)
                {
                    Debug.Log(collider.name);
                    desPoint = collider.transform.position;
                    detect++;
                    break;
                }
            }
        }

        if (detect == 0) isMoving = false;
    }
}
