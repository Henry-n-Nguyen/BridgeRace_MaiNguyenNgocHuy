using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HuySpace;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Transform Map01;
    [SerializeField] private Transform Map02;
    [SerializeField] private Transform Map03;

    [SerializeField] private GameObject brickPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBrick(3, Map01);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnBrick(int quantity, Transform holder)
    {
        for (int i = 0; i < quantity; i++)
        {
            for (int j = 0; j < quantity; j++)
            {
                Vector3 pos = Vector3.right * i + Vector3.forward * j + Vector3.up * 0.7f;

                Instantiate(brickPrefab, pos, brickPrefab.transform.rotation, holder);
            }
        }
    }
}
