using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HuySpace;

public class StepBrick : MonoBehaviour
{
    [SerializeField] ColorData colorData;
    [SerializeField] Renderer meshRenderer;
    [SerializeField] Collider stepCollider;

    private void OnCollisionEnter(Collision collision)
    {
        Character character = collision.gameObject.GetComponent<Character>();
        if (!character.IsRanOutOfBrick())
        {
            Physics.IgnoreCollision(stepCollider, collision.collider, true);
        }
        else
        {
            Physics.IgnoreCollision(stepCollider, collision.collider, false);
        }
    }
}
