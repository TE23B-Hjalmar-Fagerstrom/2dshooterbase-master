using UnityEngine;

public class AlienControler : MonoBehaviour
{
    [SerializeField]
    float speed = 3;

    float timeSincelastTurn = 0;
    [SerializeField]
    float timeBetweenTurn = 1.5f;

    public Animator animator;

    [SerializeField]
    GameObject groundCheckerLeft;
    [SerializeField]
    GameObject groundCheckerRight;

    [SerializeField]
    LayerMask groundLayer;

    Vector2 movement = Vector2.left;

    void Update()
    {
        bool isGroundedleft = Physics2D.OverlapCircle(
        groundCheckerLeft.transform.position,
        .1f,
        groundLayer
        );

        timeSincelastTurn += Time.deltaTime;

        if (timeSincelastTurn >= timeBetweenTurn)
        {
            movement *= -1;
            timeSincelastTurn = 0;
        }

        transform.Translate(movement * speed * Time.deltaTime);

        if (movement.x > 0)
        {
            animator.SetBool("walking left", false);
        }
        else
        {
            animator.SetBool("walking left", true);
        }

    }
}
