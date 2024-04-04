using HuySpace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public static Platform instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    public void SpawnBrick(GameObject brickPrefab, int quantity, Transform holder)
    {
        for (int i = 0; i < quantity; i++)
        {
            for (int j = 0; j < quantity; j++)
            {
                Vector3 pos = Vector3.right * (i + 3) + Vector3.forward * (j + 3) + Vector3.up * 0.7f;

                BrickPool.instance.SpawnPooledBrick(pos);
            }
        }
    }
}
