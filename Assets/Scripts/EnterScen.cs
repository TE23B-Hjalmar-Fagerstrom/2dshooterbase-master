using UnityEngine;

public class EnterScen : MonoBehaviour
{
    public jumperControler player;

    [SerializeField]
    float speed = 5f;

    bool landed = false;

    Vector2 spawn = Vector2.down;


    void Update()
    {
        player = GameObject.Find("jumperControler").GetComponent<jumperControler>();

        Vector2 movement = Vector2.down;

        transform.Translate(movement * speed * Time.deltaTime);

        if (landed == false)
        {
            speed -= 0.001f;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        speed = 0;
        landed = true;
        player.transform.Translate(spawn);
    }
}
