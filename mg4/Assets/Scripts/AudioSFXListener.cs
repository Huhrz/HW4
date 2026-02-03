using UnityEngine;

public class AudioSFXListener : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pointClip;
    [SerializeField] private AudioClip loseClip;

    private bool subscribed = false;

    private void Awake()
    {
        if (audioSource == null) audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        TrySubscribe();
    }

    private void Update()
    {
        if (!subscribed) TrySubscribe();
    }

    private void OnDisable()
    {
        if (subscribed && GameManager.Instance != null)
        {
            GameManager.Instance.OnScoreChanged -= OnScoreChanged;
            GameManager.Instance.OnGameOver -= OnGameOver;
        }
        subscribed = false;
    }

    private void TrySubscribe()
    {
        if (subscribed) return;
        if (GameManager.Instance == null) return;

        GameManager.Instance.OnScoreChanged += OnScoreChanged;
        GameManager.Instance.OnGameOver += OnGameOver;
        subscribed = true;
    }

    private void OnScoreChanged(int newScore)
    {
        if (audioSource != null && pointClip != null)
            audioSource.PlayOneShot(pointClip);
    }

    private void OnGameOver()
    {
        if (audioSource != null && loseClip != null)
            audioSource.PlayOneShot(loseClip);
    }
}