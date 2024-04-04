using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using HuySpace;

public static class SimplePool
{
    static Dictionary<ColorType, Pool> poolInstance = new Dictionary<ColorType, Pool>();

    public static void Preload(GameUnit prefab, int amount, Transform parent = null)
    {
        if (prefab != null && !poolInstance.ContainsKey(prefab.colorType))
        {
            poolInstance.Add(prefab.colorType, new Pool(prefab, amount, parent));
        }
    }

    public static T Spawn<T>(ColorType colorType, Vector3 pos, Quaternion rot) where T : GameUnit
    {
        return poolInstance[colorType].Spawn(pos, rot) as T;
    }

    public static void Despawn(GameUnit gameUnit)
    {
        poolInstance[gameUnit.colorType].Despawn(gameUnit);
    }

    public static void CollectAll()
    {
        foreach (var pool in poolInstance)
        {
            pool.Value.Collect();
        }
    }
}

public class Pool : MonoBehaviour
{
    Transform parent;

    GameUnit prefab;

    // List object in pool
    Queue<GameUnit> inactives = new Queue<GameUnit>();

    // List object out pool
    List<GameUnit> actives = new List<GameUnit>();

    public Pool(GameUnit prefab, int initialQty, Transform parent)
    {
        this.parent = parent;
        this.prefab = prefab;
        inactives = new Queue<GameUnit>(initialQty);
        actives = new List<GameUnit>();
    }

    // Preload : Khoi tao Pool
    public void Preload(GameUnit prefab, int amount, Transform parent)
    {
        this.parent = parent;
        this.prefab = prefab;

        for (int i = 0; i < amount; i++)
        {
            Despawn(Spawn(Vector3.zero, Quaternion.identity));
        }
    } 

    // Spawn : Lay phan tu from Pool
    public GameUnit Spawn(Vector3 pos, Quaternion rot)
    {
        GameUnit unit;

        if (inactives.Count <= 0)
        {
            unit = Instantiate(prefab, parent);
        }
        else
        {
            unit = inactives.Dequeue();
        }

        unit.TF.SetPositionAndRotation(pos, rot);
        actives.Add(unit);
        unit.gameObject.SetActive(true);

        return unit;
    } 

    // Despawn : Tra lai phan tu
    public void Despawn(GameUnit unit)
    {
        if (unit != null && unit.gameObject.activeSelf)
        {
            actives.Remove(unit);
            inactives.Enqueue(unit);
            unit.gameObject.SetActive(false);
        }
    }


    // Collect : thu thap tat ca phan tu ve Pool
    public void Collect()
    {
        while (actives.Count > 0)
        {
            Despawn(actives[0]);
        }
    }


    // Release : Destroy (Clear) tat ca phan tu cua Pool
    public void Release()
    {
        Collect();
        while (inactives.Count > 0)
        {
            Destroy(inactives.Dequeue().gameObject);
        }
        inactives.Clear();
    }
}
