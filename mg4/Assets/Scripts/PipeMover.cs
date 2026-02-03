using UnityEngine;

public class PipeMover : MonoBehaviour
{
    private float moveSpeed = 2.5f;
    private float destroyX = -12f;


    public void Init(float speed)
    {
        moveSpeed = speed;
    }

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsGameOver) return;

        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}