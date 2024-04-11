using HuySpace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Entrance : MonoBehaviour
{
    [SerializeField] Collider collide;
    [SerializeField] NavMeshObstacle navMeshStacle;

    private void OnTriggerEnter(Collider other)
    {
        navMeshStacle.enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {
        Character character = other.GetComponent<Character>();

        navMeshStacle.enabled = true;
        character.currentMap++;
    }
}
