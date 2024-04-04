using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using HuySpace;

public class PoolController : MonoBehaviour
{
    [SerializeField] PoolAmount[] poolAmounts;

    void Awake()
    {
        for (int i = 0; i < poolAmounts.Length; i++)
        {
            SimplePool.Preload(poolAmounts[i].prefab, poolAmounts[i].amount, poolAmounts[i].color, poolAmounts[i].parent);
        }

        Dictionary<ColorType, Pool> simplePool = SimplePool.poolInstance;

        for (int i = 1; i <= simplePool.Count; i++)
        {
            Pool pool = SimplePool.poolInstance[(ColorType) i];
            pool.Preload(pool.prefab, pool.inactives.Count, pool.parent);
        }
    }    
}

[System.Serializable]
public class PoolAmount
{
    [Header("-- Pool Amount --")]
    public Transform parent;
    public GameUnit prefab;
    public int amount;
    public ColorType color;

    public PoolAmount(Transform parent, GameUnit prefab, ColorType color, int amount)
    {
        this.parent = parent;
        this.prefab = prefab;
        this.amount = amount;
        this.color = color;
    }
}
