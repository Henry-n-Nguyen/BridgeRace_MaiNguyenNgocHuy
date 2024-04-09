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
    [SerializeField] NavMeshObstacle navMeshStacle;

    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if (!character.IsRanOutOfBrick() || character.OnDownStair() || character.color == colorType)
        {
            navMeshStacle.enabled = false;

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
        else
        {
            navMeshStacle.enabled = true;
        }
    }

    public void ChangeColor(ColorType color)
    {
        colorType = color;
        meshRenderer.material = colorData.GetMat(color);
    }
}
