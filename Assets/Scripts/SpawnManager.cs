using NUnit.Framework;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    public GameObject[] enemies;
    public int i;

    private Vector3[] squareSpawnVectors = {
        new Vector3(-10, 2, 10),
        new Vector3(15, 2, 10),
        new Vector3(-10, 2, -12), 
        new Vector3(15, 2, -12) };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomEnemy()
    {
        i = Random.Range(0, enemies.Length);

        switch (i)
        {
            case 0:
                SpawnSquare(i);
                break;

            case 1:
                SpawnCircle(i);
                break;

            default:
                break;
        }
    }

    void SpawnSquare(int i)
    {
        Instantiate(enemies[i], squareSpawnVectors[Random.Range(0, squareSpawnVectors.Length)], enemies[i].transform.rotation);
    }

    void SpawnCircle(int i)
    {
        Instantiate(enemies[i], new Vector3(22, 2.8f, Random.Range(22, -23)), enemies[i].transform.rotation);
    }
}
