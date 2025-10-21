using UnityEngine;

public class EnterScen : MonoBehaviour
{   
    [SerializeField]
    public jumperControler player;

    [SerializeField]
    float speed = 5f;

    bool landed = false;

    Vector2 spawn = Vector2.down;


    void Update()
    {
        Vector2 movement = Vector2.down;
        spawn.y = -3;
        spawn.x = -8.5f;

        transform.Translate(movement * speed * Time.deltaTime);

        if (landed == false)
        {
            speed -= 0.001f;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            speed = 0;
            landed = true;
            player.transform.position = spawn;
        }
    }
}
