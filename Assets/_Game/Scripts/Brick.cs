using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HuySpace;
using static UnityEditor.PlayerSettings;

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
                Invoke(nameof(Respawn), 3f);

                SimplePool.Despawn(this);
            }
        }
    }

    private void Respawn()
    {
        SimplePool.Spawn<Brick>(colorType, transform.position, Quaternion.identity);
    }

    public void ChangeColor(ColorType color)
    {
        colorType = color;
        meshRenderer.material = colorData.GetMat(color);
    }
}
