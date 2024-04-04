using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HuySpace;

public class GameUnit : MonoBehaviour
{
    private Transform tf;

    public Transform TF
    {
        get
        {
            //tf = tf ?? gameObject.transform;
            if (tf == null)
            {
                tf = transform;
            }

            return tf;
        }
    }

    public ColorType colorType;

    public void OnDespawn(float delay)
    {
        Invoke(nameof(OnDespawn), delay);
    }

    private void OnDespawn()
    {
        SimplePool.Despawn(this);
    }
}
