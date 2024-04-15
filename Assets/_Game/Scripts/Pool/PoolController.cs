using System.Collections.Generic;
using UnityEngine;
using HuySpace;

public class PoolController : MonoBehaviour
{
    [SerializeField] private PoolAmount[] poolAmounts;

    void Awake()
    {
        for (int i = 0; i < poolAmounts.Length; i++)
        {
            SimplePool.Preload(poolAmounts[i].color, poolAmounts[i].prefab, poolAmounts[i].amount, poolAmounts[i].parent);
        }
    }

    public List<int> GetAmountInPool() 
    {
        List<int> tmpArray = new List<int>();

        for (int i = 0; i < poolAmounts.Length; i++) tmpArray.Add(poolAmounts[i].amount);

        return tmpArray;
    }

    public int GetAmountOfPool()
    {
        return poolAmounts.Length;
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
