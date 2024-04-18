using HuySpace;
using Palmmedia.ReportGenerator.Core.CodeAnalysis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;

    [SerializeField] private Transform mapHolder;
    [SerializeField] private GameObject[] mapPrefabs;

    private List<GameObject> createdMap = new List<GameObject>();

    void Awake()
    {
        instance = this;
    }

    public void SpawnMap()
    {
        GameObject map;
        foreach (GameObject mapPref in mapPrefabs)
        {
            map = Instantiate(mapPref, mapPref.transform.position, mapPref.transform.rotation, mapHolder);
            createdMap.Add(map);
        }
    }

    public void ResetMap()
    {
        foreach (GameObject mapPref in createdMap) Destroy(mapPref.gameObject);
        createdMap.Clear();
        SpawnMap();
    }
}
