using UnityEditor;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    private EnemySpawner spawner;

    float leftSpawn = -8f;
    float rightSpawn = 8f;

    [SerializeField]
    float speed = 2;

    [SerializeField]
    GameObject Explosion;
    [SerializeField]
    GameObject newEnemyPrefab;

    void Start()
    {
        spawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();

        Vector2 position = new();
        position.x = Random.Range(leftSpawn, rightSpawn);
        position.y = Random.Range(Camera.main.orthographicSize + 1f, Camera.main.orthographicSize + 2f);

        transform.position = position;
    }

    void Update()
    {
        Vector2 movement = Vector2.down;
        transform.Translate(movement * speed * Time.deltaTime);

        if (transform.position.y < -Camera.main.orthographicSize - 1)
        {
            Destroy(this.gameObject);
        }

        if (spawner.kills == 15)
        {
            spawner.timeBetweenSpawns = 99999;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
        Instantiate(Explosion, transform.position, Quaternion.identity);

        for (int i = 0; i < 5; i++)
        {
            Instantiate(newEnemyPrefab, transform.position, Quaternion.identity);  
        }

        spawner.kills += 1;
    }
}
