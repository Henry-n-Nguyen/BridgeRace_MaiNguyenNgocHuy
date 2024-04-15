using HuySpace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPos : MonoBehaviour
{
    [SerializeField] private Transform[] podiumPoint;
    [SerializeField] private MeshRenderer[] podiumMeshRenderer;

    [SerializeField] ColorData colorData;


    private List<Character> characters = new List<Character>();

    private void Start()
    {
        characters = Platform.instance.GetListOfCharacters();
    }

    private void OnTriggerEnter(Collider other)
    {
        CameraFollow.instance.target = this.transform;
        CameraFollow.instance.EndLevel();

        Character no1 = other.GetComponent<Character>();

        SetUpPodium(no1, 1);

        int rank = 2;

        foreach (Character character in characters)
        {
            if (character.color != no1.color && rank <= 3)
            {
                SetUpPodium(character, rank);
            }
        }
    }

    private void SetUpPodium(Character character, int rank)
    {
        character.transform.rotation = Quaternion.Euler(Vector3.zero);

        podiumMeshRenderer[rank-1].material = colorData.GetMat(character.color);

        character.WarpTo(podiumPoint[rank-1].transform.position);

        character.rank = rank;

        character.ChangeState(new WinState());
    } 
}
