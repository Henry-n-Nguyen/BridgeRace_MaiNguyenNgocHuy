using HuySpace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;

    [SerializeField] private Transform mapHolder;
    [SerializeField] private GameObject[] mapPrefabs; 

    void Awake()
    {
        instance = this;
    }

    public void SpawnMap()
    {
        foreach (GameObject mapPref in mapPrefabs)
        {
            Instantiate(mapPref, mapPref.transform.position, mapPref.transform.rotation, mapHolder);
        }
    }
}
