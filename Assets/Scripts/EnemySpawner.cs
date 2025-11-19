using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    int random => UnityEngine.Random.Range(1, 11);

    [SerializeField]
    public int kills;

    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    GameObject newEnemyPrefab;


    float timeSincelastSpawn = 0;
    [SerializeField]
    public float timeBetweenSpawns = 1f;

    void Update()
    {
        timeSincelastSpawn += Time.deltaTime;

        if (timeSincelastSpawn >= timeBetweenSpawns)
        {
            if (random <= 5)
            {
                Instantiate(enemyPrefab);
            }
            else
            {
                Instantiate(newEnemyPrefab); 
            }
            
            timeSincelastSpawn = 0;
        }
    }
}
