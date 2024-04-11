using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HuySpace;

public class LevelManager : MonoBehaviour
{
    [SerializeField] bool isSpawn;

    // Start is called before the first frame update
    void Start()
    {
        OnInit();
    }

    void OnInit()
    {
        MapManager.instance.SpawnMap();
        Platform.instance.SpawnCharacter();
        Platform.instance.SpawnBrick();
    }
}
