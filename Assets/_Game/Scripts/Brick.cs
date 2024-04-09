using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HuySpace;

public class Brick : GameUnit
{
    [SerializeField] ColorData colorData;
    [SerializeField] Renderer meshRenderer;

    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if (character.color == colorType)
        {
            character.AddBrick();
            gameObject.SetActive(false);
        }
    }

    public void ChangeColor(ColorType color)
    {
        colorType = color;
        meshRenderer.material = colorData.GetMat(color);
    }
}
