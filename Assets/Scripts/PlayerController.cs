using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    private float shootCooldown = 0.4f;
    private float lastShotTime;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleMovement();
        HandleShooting();
    }

    void HandleMovement()
    {
        float input = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(input * moveSpeed, rb.linearVelocity.y);

        if (input > 0) transform.localScale = new Vector3(0.5f, 1f, 1f);
        if (input < 0) transform.localScale = new Vector3(-0.5f, 1f, 1f);

        if (input != 0)
            AudioManager.Instance?.PlayWalk();
    }

    void HandleShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > lastShotTime + shootCooldown)
        {
            lastShotTime = Time.time;
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bubble"))
        {
            GameManager.Instance.PlayerDied();
        }
    }
}