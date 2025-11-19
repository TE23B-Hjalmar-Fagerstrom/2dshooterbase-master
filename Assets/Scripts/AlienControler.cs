using System;
using UnityEngine;

public class AlienControler : MonoBehaviour
{
    [SerializeField]
    float speed = 3;

    public Animator animator;

    [SerializeField]
    GameObject groundCheckerLeft;
    [SerializeField]
    GameObject groundCheckerRight;

    [SerializeField]
    LayerMask groundLayer;

    Vector2 movement = Vector2.left;

    void FixedUpdate()
    {
        bool isGroundedleft = Physics2D.OverlapCircle(
        groundCheckerLeft.transform.position,
        -.1f,
        groundLayer
        );

        bool isGroundedRight = Physics2D.OverlapCircle(
        groundCheckerRight.transform.position,
        .1f,
        groundLayer
        );

        if (isGroundedleft == false || isGroundedRight == false)
        {
            movement *= -1;
        }

        transform.Translate(movement * speed * Time.deltaTime);
    }

    void Update()
    {
        if (movement.x > 0)
        {
            animator.SetBool("walking left", false);
        }
        else
        {
            animator.SetBool("walking left", true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            movement *= -1;
        }
    }
}
