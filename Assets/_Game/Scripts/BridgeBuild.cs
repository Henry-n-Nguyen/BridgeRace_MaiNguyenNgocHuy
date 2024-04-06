using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeBuild : MonoBehaviour
{
    [SerializeField] private bool isBuild;
    [SerializeField] private Transform bridgeTransform;
    [SerializeField] private GameObject brickInBridgePrefab;

    Vector3 pos;

    private void Start()
    {
        pos = Vector3.down * 0.57735026919f * 16f + Vector3.back * 16f + bridgeTransform.position;
        Instantiate(brickInBridgePrefab, pos, brickInBridgePrefab.transform.rotation, bridgeTransform);
    }

    void Update()
    {
        if (isBuild)
        {
            pos += Vector3.up * 0.57735026919f + Vector3.forward;
            Instantiate(brickInBridgePrefab, pos, brickInBridgePrefab.transform.rotation, bridgeTransform);
            isBuild = false;
        }
    }
}
