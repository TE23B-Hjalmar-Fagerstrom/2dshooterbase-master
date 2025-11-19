using UnityEngine;
using UnityEngine.Rendering;

public class ConfettiControler : MonoBehaviour
{
    private ConfettiSpawner spawner;

    float leftSpawn = -9.5f;
    float rightSpawn = 9.5f;
    Color color;

    [SerializeField]
    float speed = 2;

    void Start()
    {
        spawner = GameObject.Find("ConfettiSpawner").GetComponent<ConfettiSpawner>();

        Vector2 position = new();
        position.x = Random.Range(leftSpawn, rightSpawn);
        position.y = Random.Range(Camera.main.orthographicSize + 1f, Camera.main.orthographicSize + 2f);

        transform.position = position;

        color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

        this.GetComponent<Renderer>().material.color = color;
        
        
    }

    void Update()
    {
        Vector2 movement = Vector2.down;
        transform.Translate(movement * speed * Time.deltaTime);

        if (transform.position.y < -Camera.main.orthographicSize - 1)
        {
            Destroy(this.gameObject);
        } 
    }
}
