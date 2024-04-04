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

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Rigidbody rb;

    private void Awake()
    {
        ChangeColor(ColorType.Red);
    }

    public override void Moving()
    {
        if (!isMoving) ChangeState(new IdleState());

        base.Moving();

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

        if (isMoving) ChangeState(new PatrolState());
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
            if (collider.gameObject.CompareTag("Brick"))
            {
                if (collider.GetComponent<Brick>().color == color)
                {
                    desPoint = collider.transform.position;
                    detect++;
                    break;
                }
            }
        }

        if (detect == 0) isMoving = false;
    }

    private bool OnGround()
    {
        return Physics.Raycast(playerTransform.position, Vector3.down, 10f, groundLayer);
    }
}
