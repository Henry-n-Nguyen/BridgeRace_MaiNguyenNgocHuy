using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HuySpace;
using Unity.VisualScripting;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] bool isReset;
    [SerializeField] bool isNextLevel;
    [SerializeField] bool isActive;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        OnEnter();
    }

    private void Update()
    {
        if (isReset)
        {
            ResetLevel();
            isReset = false;
        }

        if (isNextLevel)
        {
            NextLevel();
            isReset = false;
        }

        if (isActive)
        {
            Platform.instance.ActiveCharacter();
            isActive = false;
        }
    }

    public void OnEnter()
    {
        MapManager.instance.SpawnMap();
        Platform.instance.SpawnCharacter();
        Platform.instance.SpawnBrick();
    }

    public void ResetLevel()
    {
        MapManager.instance.ResetMap();
        Platform.instance.ResetPlatform();
    }

    public void NextLevel()
    {
        ResetLevel();
    }
}
