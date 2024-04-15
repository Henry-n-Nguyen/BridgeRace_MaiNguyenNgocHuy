using HuySpace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public static Platform instance;

    [SerializeField] private PoolController pool;

    [SerializeField] private Vector3 offset;

    [SerializeField] private Transform[] spawnPoint;
    [SerializeField] private Transform characterHolder;

    [SerializeField] private Character playerPrefab;
    [SerializeField] private Character competitorPrefab;

    private List<int> amounts;

    public List<GameUnit> bricks;
    public List<Character> characters;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        amounts = pool.GetAmountInPool();
    }

    public void SpawnBrick()
    {
        int randomNumber = (int)Mathf.Round(Random.Range(0, amounts.Count - 1));

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                Vector3 pos = Vector3.right * (2 * i - 8) + Vector3.forward * (2 * j - 8) + Vector3.up * 0.6f;

                randomNumber = (int)Mathf.Round(Random.Range(0f, amounts.Count - 0.5f));

                Brick brick = SimplePool.Spawn<Brick>((ColorType)randomNumber + 1, pos, Quaternion.identity);
                brick.ChangeColor((ColorType)randomNumber + 1);

                bricks.Add(brick);

                amounts[randomNumber]--;

                if (amounts[randomNumber] == 0) amounts.Remove(amounts[randomNumber]);
            }
        }
    }

    public void SpawnBrickByColor(ColorType color)
    {
        foreach (GameUnit unit in bricks)
        {
            if (unit.colorType == color) unit.transform.position += offset;
        }
    }

    public void SpawnCharacter()
    {
        for (int i = 1; i <= spawnPoint.Length; i++)
        {
            Character character;
            if (i == (int)ColorType.Blue)
            {
                character = Instantiate(playerPrefab, spawnPoint[i - 1].position, playerPrefab.transform.rotation, characterHolder);
                CameraFollow.instance.target = character.gameObject.transform;
            }
            else
            {
                character = Instantiate(competitorPrefab, spawnPoint[i - 1].position, competitorPrefab.transform.rotation, characterHolder);
                character.ChangeColor((ColorType)i);
            }

            characters.Add(character);
        }
    }

    public void ActiveCharacter()
    {
        foreach(Character character in characters)
        {
            character.isMoving = true;
        }
    }

    public void ResetPlatform()
    {
        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].OnInit();
            characters[i].transform.position = spawnPoint[i].position;
        };
    }

    public List<Character> GetListOfCharacters()
    {
        return characters;
    }
}
