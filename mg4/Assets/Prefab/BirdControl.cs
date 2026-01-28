using UnityEngine;

public class BirdControl : MonoBehaviour
{
    [SerializeField] private float flapForce = 3f;
    Rigidbody2D rb;
    bool dead = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (dead) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * flapForce, ForceMode2D.Impulse);
            GameEvents.OnFlap?.Invoke();
        }
    }

    public void SetDead(bool isDead)
    {
        dead = isDead;
    }
}