using UnityEngine;

public class BoltControler : MonoBehaviour
{
    [SerializeField]
    GameObject boltPrefab;

    [SerializeField]
    float speed;

    void Update()
    {
        Vector2 movement = Vector2.up;
        transform.Translate(movement * speed * Time.deltaTime);

        if (transform.position.y > Camera.main.orthographicSize + 1)
        {
            Destroy(boltPrefab);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {     
            Destroy(this.gameObject);
        }
    }
}
