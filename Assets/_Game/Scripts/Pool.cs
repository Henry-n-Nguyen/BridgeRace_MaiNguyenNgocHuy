using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pool : MonoBehaviour
{
    Transform root = null;

    GameObject prefab;

    Queue<GameObject> inactive;
    List<GameObject> active;

    public Pool(GameObject prefab, int initialQty, Transform parent)
    {
        root = parent;
        this.prefab = prefab;
        inactive = new Queue<GameObject>(initialQty);
        active = new List<GameObject>();
    }

    // Spawn
    // Preload
    // Despawn
    // Collect
    // CollectAll

}
