using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovingByJoyStick : MonoBehaviour
{
    enum Direct
    {
        Forward,
        ForwardRight,
        Right,
        BackRight,
        Back,
        BackLeft,
        Left,
        ForwardLeft,
        None = -1
    }


    [SerializeField] private Character playerScript;
    [SerializeField] private Transform playerTransform;

    [SerializeField] private PlayerInput playerInput;

    [SerializeField] private InputAction moveAction;

    [SerializeField] private float moveSpeed = 5f;
    private void Start()
    {
        moveAction = playerInput.actions.FindAction("Moving");
    }

    private void Update()
    {
        Moving();
    }

    private void Moving()
    {
        Vector2 inputVector = moveAction.ReadValue<Vector2>();
        Direct direction = CheckDirection(inputVector);

        switch (direction)
        {
            case Direct.None: 
                playerScript.ChangeState(new IdleState());
                break;
            default: 
                Rotate(direction);
                playerScript.ChangeState(new PatrolState());
                break;
        }

        playerTransform.position += (Vector3.right * inputVector.x + Vector3.forward * inputVector.y) * Time.deltaTime * moveSpeed;
    }

    private void Rotate(Direct dir)
    {
        switch (dir)
        {
            case Direct.Forward:
                playerTransform.rotation = Quaternion.Euler(Vector3.zero);
                break;
            case Direct.ForwardRight:
                playerTransform.rotation = Quaternion.Euler(Vector3.up * 45f);
                break;
            case Direct.Right:
                playerTransform.rotation = Quaternion.Euler(Vector3.up * 90f);
                break;
            case Direct.BackRight:
                playerTransform.rotation = Quaternion.Euler(Vector3.up * 135f);
                break;
            case Direct.Back:
                playerTransform.rotation = Quaternion.Euler(Vector3.up * 180f);
                break;
            case Direct.ForwardLeft:
                playerTransform.rotation = Quaternion.Euler(Vector3.down * 45f);
                break;
            case Direct.Left:
                playerTransform.rotation = Quaternion.Euler(Vector3.down * 90f);
                break;
            case Direct.BackLeft:
                playerTransform.rotation = Quaternion.Euler(Vector3.down * 135f);
                break;
        }
    }

    private Direct CheckDirection(Vector2 direction)
    {
        switch ((int) Mathf.Round(direction.x))
        {
            case 1:
                switch ((int)Mathf.Round(direction.y))
                {
                    case 1: return Direct.ForwardRight;
                    case 0: return Direct.Right;
                    case -1: return Direct.BackRight;
                }
                return Direct.None;
            case 0:
                switch ((int)Mathf.Round(direction.y))
                {
                    case 1: return Direct.Forward;
                    case 0: return Direct.None;
                    case -1: return Direct.Back;
                }
                return Direct.None;
            case -1:
                switch ((int)Mathf.Round(direction.y))
                {
                    case 1: return Direct.ForwardLeft;
                    case 0: return Direct.Left;
                    case -1: return Direct.BackLeft;
                }
                return Direct.None;
        }

        return Direct.None;
    }
}
