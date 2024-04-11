using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HuySpace;

public class Brick : GameUnit
{
    const string LAYER_PLAYER = "Player";

    [SerializeField] ColorData colorData;
    [SerializeField] Renderer meshRenderer;
    [SerializeField] Collider collide;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer(LAYER_PLAYER))
        {
            Character character = other.GetComponent<Character>();
            if (character.color == colorType)
            {
                character.AddBrick();
                Invoke(nameof(Respawn), 2f);

                Platform.instance.bricks.Remove(this);

                meshRenderer.enabled = false;
                collide.enabled = false;
            }
        }
    }

    private void Respawn()
    {
        Platform.instance.bricks.Add(this);

        meshRenderer.enabled = true;
        collide.enabled = true;
    }

    public void ChangeColor(ColorType color)
    {
        colorType = color;
        meshRenderer.material = colorData.GetMat(color);
    }
}
