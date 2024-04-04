using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HuySpace;

public class Brick : MonoBehaviour
{
    const string PLAYER = "Player";

    [SerializeField] ColorData colorData;
    [SerializeField] Renderer meshRenderer;
    [SerializeField] Collider collide;
    public ColorType color;

    private Character characterScript;

    private void Start()
    {
        ChangeColor((ColorType) (int) Mathf.Round(Random.Range(0.6f, 4.5f)));
    }

    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if (character.color == color)
        {
            character.AddBrick();
            collide.enabled = false;
            meshRenderer.enabled = false;
        }
    }

    public void ChangeColor(ColorType colorType)
    {
        color = colorType;
        meshRenderer.material = colorData.GetMat(colorType);
    }
}
