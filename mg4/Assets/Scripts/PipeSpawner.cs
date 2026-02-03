using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private GameObject pipePairPrefab;

    [Header("Spawn Timing")]
    [SerializeField] private float spawnInterval = 1.6f;

    [Header("Gap Position Randomization")]
    [SerializeField] private float minY = -1.5f;
    [SerializeField] private float maxY = 1.5f;

    [Header("Pipe Movement")]
    [SerializeField] private float pipeMoveSpeed = 2.5f;

    private float timer = 0f;

    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsGameOver) return;

        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnPipe();
        }
    }

    private void SpawnPipe()
    {
        float y = Random.Range(minY, maxY);

        Vector3 spawnPos = new Vector3(transform.position.x, y, 0f);
        GameObject pipePair = Instantiate(pipePairPrefab, spawnPos, Quaternion.identity);

        PipeMover mover = pipePair.GetComponent<PipeMover>();
        if (mover != null)
        {
            mover.Init(pipeMoveSpeed);
        }
    }
}