using UnityEngine;
using UnityEngine.SceneManagement;

public class jumperControler : MonoBehaviour
{
    [SerializeField]
    float speed = 0.02f;

    [SerializeField]
    float jumpForce = 2;

    [SerializeField]
    GameObject groundChecker;

    [SerializeField]
    LayerMask groundLayer;

    void FixedUpdate()
    {
        bool isGrounded = Physics2D.OverlapCircle(
            groundChecker.transform.position,
            .1f,
            groundLayer
        );

        if (Input.GetAxisRaw("Jump") > 0 && isGrounded == true)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        Vector2 movement = Vector2.right * x;

        transform.Translate(movement * speed * Time.deltaTime);

        Vector2 spawn = transform.position;
        spawn.y = -2;
        spawn.x = -8.5f;

        if (transform.position.y <= -10)
        {
            transform.position = spawn;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            SceneManager.LoadScene("GameOver");
        }
        
        if (collision.gameObject.tag == "flag")
        {
            SceneManager.LoadScene("WinScreen");
        }
        
    }
}
