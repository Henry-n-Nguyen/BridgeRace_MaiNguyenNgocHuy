using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolController : MonoBehaviour
{
    [SerializeField] PoolAmount[] poolAmounts;

    void Awake()
    {
        for (int i = 0; i <= poolAmounts.Length; i++)
        {
            SimplePool.Preload(poolAmounts[i].prefab, poolAmounts[i].amount, poolAmounts[i].parent);
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

    public PoolAmount(Transform parent, GameUnit prefab, int amount)
    {
        this.parent = parent;
        this.prefab = prefab;
        this.amount = amount;
    }
}
