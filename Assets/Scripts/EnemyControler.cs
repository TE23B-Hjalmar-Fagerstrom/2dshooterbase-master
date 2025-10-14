using UnityEditor;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    int kills = 0;

    float leftSpawn = -8f;
    float rightSpawn = 8f;

    [SerializeField]
    float speed = 2;

    [SerializeField]
    GameObject Explosion;
    [SerializeField]
    GameObject earth;

    void Start()
    {

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

        if (kills >= 1)
        {
            Vector2 position = new();
            position.x = 0;
            position.y = 5;

            transform.position = position;
            Instantiate(earth, transform.position, Quaternion.identity);
            earth.transform.Translate(movement * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
        Instantiate(Explosion, transform.position, Quaternion.identity);
        kills++;
    }
}
