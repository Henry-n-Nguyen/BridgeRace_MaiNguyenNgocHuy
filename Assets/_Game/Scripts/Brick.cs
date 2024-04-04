using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HuySpace;

public class Brick : MonoBehaviour
{
    [SerializeField] ColorData colorData;
    [SerializeField] Renderer meshRenderer;
    [SerializeField] Collider collide;
    public ColorType color;

    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if (character.color == color)
        {
            character.AddBrick();
            gameObject.SetActive(false);
        }
    }

    public void ChangeColor(ColorType colorType)
    {
        color = colorType;
        meshRenderer.material = colorData.GetMat(colorType);
    }
}
