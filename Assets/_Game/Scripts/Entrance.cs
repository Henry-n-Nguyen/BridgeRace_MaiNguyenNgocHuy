using HuySpace;
using UnityEngine;
using UnityEngine.AI;

public class Entrance : MonoBehaviour
{
    [SerializeField] Collider collide;
    [SerializeField] NavMeshObstacle navMeshStacle;

    private void OnTriggerEnter(Collider other)
    {
        //navMeshStacle.enabled = true;

        Character character = other.GetComponent<Character>();

        character.isEnterEntrance = true;

        Platform.instance.SpawnBrickByColor(character.color);

        character.WarpTo(transform.position + Vector3.forward * 1f);
    }
}
