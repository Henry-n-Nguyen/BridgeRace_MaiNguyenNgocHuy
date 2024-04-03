using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HuySpace;

public class Brick : MonoBehaviour
{
    const string PLAYER = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(PLAYER)) other.GetComponent<Character>().AddBrick();
    }
}
