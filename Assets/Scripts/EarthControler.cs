using UnityEngine;
using UnityEngine.SceneManagement;

public class EarthControler : MonoBehaviour
{
    private EnemySpawner spawner;

    [SerializeField]
    float speed = 2;

    void Start()
    {
        spawner = GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>();
    }

    void Update()
    {
        if (spawner.kills >= 15)
        {
            Vector2 movement = Vector2.down;

            transform.Translate(movement * speed * Time.deltaTime);
        }

        if (transform.position.y <= -1)
        {
            speed = 0;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Platforms");
        }
    }
}
