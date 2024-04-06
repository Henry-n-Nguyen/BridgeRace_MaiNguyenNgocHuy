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
        Platform.instance.SpawnBrick(Map01.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
