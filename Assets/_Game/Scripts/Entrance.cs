using HuySpace;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

public class Entrance : MonoBehaviour
{
    [SerializeField] Collider collide;
    [SerializeField] NavMeshObstacle navMeshStacle;

    [SerializeField] private int mapHolderId;

    private void OnTriggerEnter(Collider other)
    {
        //navMeshStacle.enabled = true;

        Character character = other.GetComponent<Character>();

        Platform.instance.SpawnBrickByColor(character.color, mapHolderId + 1);

        character.currentMap = mapHolderId + 1;

        character.isEnterEntrance = true;

        character.WarpTo(transform.position + Vector3.forward * 1.5f);
    }
}
