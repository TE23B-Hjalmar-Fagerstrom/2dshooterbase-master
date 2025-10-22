using UnityEngine;

public class AlienControler : MonoBehaviour
{
    [SerializeField]
    float speed = 3;

    float timeSincelastTurn = 0;
    [SerializeField]
    float timeBetweenTurn = 1.5f;
        
    Vector2 movement = Vector2.left;

    void Update()
    {
        timeSincelastTurn += Time.deltaTime;

        if (timeSincelastTurn >= timeBetweenTurn)
        {
            movement *= -1;
            timeSincelastTurn = 0;
        }

        transform.Translate(movement * speed * Time.deltaTime);
    }
}
