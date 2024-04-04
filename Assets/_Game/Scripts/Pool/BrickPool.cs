using HuySpace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickPool : MonoBehaviour
{
    public static BrickPool instance;

    private Queue<Brick> pooledBricks = new Queue<Brick>();
    private List<Brick> freeBricks = new List<Brick>();
    private int amountTopool = 8;

    [SerializeField] private Brick brickPrefab;
    [SerializeField] private Transform poolHolder;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        OnInit();
    }

    public void OnInit()
    {
        for (int i = 1; i <= 4; i++)
        {
            for (int j = 0; j < amountTopool; j++)
            {
                Brick obj = Instantiate(brickPrefab, poolHolder);

                obj.ChangeColor((ColorType)i);

                pooledBricks.Enqueue(obj);

                obj.gameObject.SetActive(false);
            }
        }
    }

    public void SpawnPooledBrick(Vector3 pos)
    {
        Brick obj = pooledBricks.Dequeue();
        freeBricks.Add(obj);

        obj.transform.position = pos;
        obj.gameObject.SetActive(true);
    } 
}
