using HuySpace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Step : GameUnit
{
    [SerializeField] ColorData colorData;
    [SerializeField] Renderer meshRenderer;
    [SerializeField] Collider stepCollider;

    private void OnCollisionEnter(Collision collision)
    {
        Character character = collision.gameObject.GetComponent<Character>();
        if (!character.IsRanOutOfBrick() || character.color == colorType || character.OnDownStair())
        {
            Physics.IgnoreCollision(stepCollider, collision.collider, true);

            if (character.color != colorType)
            {
                if (meshRenderer.enabled == false)
                {
                    meshRenderer.enabled = true;
                    character.RemoveBrick();
                    ChangeColor(character.color);
                }
                else if (character.color != colorType)
                {
                    character.RemoveBrick();
                    ChangeColor(character.color);
                }
            }
        }
        else
        {
            Physics.IgnoreCollision(stepCollider, collision.collider, false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Physics.IgnoreCollision(stepCollider, collision.collider, false);
    }

    public void ChangeColor(ColorType color)
    {
        colorType = color;
        meshRenderer.material = colorData.GetMat(color);
    }
}
