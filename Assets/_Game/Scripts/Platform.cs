using HuySpace;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public static Platform instance;

    [SerializeField] private PoolController pool;
    
    private List<int> amounts;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        amounts = pool.GetAmountInPool();
    }

    public void SpawnBrick(Vector3 rootPos)
    {
        for (int i = 0; i < amounts.Count; i++)
        {
            for (int j = 0; j < amounts[i]; j++)
            {
                Vector3 pos = Vector3.right * i + Vector3.forward * j + Vector3.up * 0.7f + rootPos;

                Brick brick = SimplePool.Spawn<Brick>((ColorType)i + 1, pos, Quaternion.identity);
                brick.ChangeColor((ColorType)i + 1);
            }
        }
    }
}
