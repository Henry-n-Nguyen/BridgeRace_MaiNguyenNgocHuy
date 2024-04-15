using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HuySpace;
using Unity.VisualScripting;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        OnEnter();
    }

    public void OnEnter()
    {
        MapManager.instance.SpawnMap();
        Platform.instance.SpawnCharacter();
        Platform.instance.SpawnBrick();
    }

    public IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(3f);
        UIManager.instance.Win();
    }

    public void ResetLevel()
    {
        MapManager.instance.ResetMap();
        Platform.instance.ResetPlatform();
        CameraFollow.instance.OnInit();
    }

    public void NextLevel()
    {
        ResetLevel();
    }
}
