using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdControl : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float flapImpulse = 6.5f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsGameOver) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Flap();
        }
    }

    private void Flap()
    {
        
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(Vector2.up * flapImpulse, ForceMode2D.Impulse);
        
        FlapSFX.Play(); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.TriggerGameOver();
        }
    }
}