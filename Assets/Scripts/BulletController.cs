using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 12f;
    private Rigidbody2D rb;
    private bool hasHit = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.up * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasHit) return;

        if (other.CompareTag("Bubble"))
        {
            hasHit = true;
            other.GetComponent<BubbleController>()?.GetHit();
            Destroy(gameObject);
        }

        if (other.CompareTag("Ceiling"))
        {
            hasHit = true;
            Destroy(gameObject);
        }
    }
}