using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    
    private Vector3 offset;


    private void Start()
    {
        offset = Vector3.back * 15f + Vector3.up * 15f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
    }
}
