using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{
    [SerializeField]
    float speed = 0.02f;

    [SerializeField]
    GameObject boltPrefab;
    [SerializeField]
    GameObject Explosion;

    float timeSincelastShot = 0;
    [SerializeField]
    float timeBetweenShots = 0.5f;

    float currentHP = 0;
    [SerializeField]
    float maxHP = 3;

    [SerializeField]
    Slider hpSlider;

    void Start()
    {
        currentHP = maxHP;
        hpSlider.maxValue = maxHP;
        hpSlider.value = currentHP;
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector2 movement = Vector2.right * inputX
                            + Vector2.up * inputY;

        transform.Translate(movement * speed * Time.deltaTime);

        //_________________________________________________________________
        // skjuta

        timeSincelastShot += Time.deltaTime;

        if (Input.GetAxisRaw("Fire1") > 0 && timeSincelastShot >= timeBetweenShots)
        {
            AudioSource speaker = GetComponent<AudioSource>();

            speaker.Play();

            // GetComponent<AudioSource>().Play();

            Instantiate(boltPrefab, transform.position, Quaternion.identity);
            timeSincelastShot = 0;
        }

        if (Input.GetKey(KeyCode.Space) && timeSincelastShot >= timeBetweenShots)
        {
            AudioSource speaker = GetComponent<AudioSource>();

            speaker.Play();

            Instantiate(boltPrefab, transform.position, Quaternion.identity);
            timeSincelastShot = 0;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            currentHP--;
            hpSlider.value = currentHP;
        }
        if (currentHP <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(Explosion, transform.position, Quaternion.identity);
            SceneManager.LoadScene("GameOver");
        }
    }

}
