using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;

    float timeSincelastSpawn = 0;
    [SerializeField]
    float timeBetweenSpawns = 1f;

    // Update is called once per frame
    void Update()
    {
        timeSincelastSpawn += Time.deltaTime;

        if (timeSincelastSpawn >= timeBetweenSpawns)
        {
            Instantiate(enemyPrefab);
            timeSincelastSpawn = 0;
        }
    }
}
