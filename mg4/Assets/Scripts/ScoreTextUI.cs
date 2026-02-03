using UnityEngine;
using TMPro;

public class ScoreTextUI : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    private bool subscribed = false;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        TrySubscribe();
    }

    private void Start()
    {
        if (GameManager.Instance != null)
            HandleScoreChanged(GameManager.Instance.Score);
        else
            HandleScoreChanged(0);
    }

    private void Update()
    {
        if (!subscribed)
            TrySubscribe();
    }

    private void OnDisable()
    {
        if (subscribed && GameManager.Instance != null)
            GameManager.Instance.OnScoreChanged -= HandleScoreChanged;

        subscribed = false;
    }

    private void TrySubscribe()
    {
        if (subscribed) return;
        if (GameManager.Instance == null) return;

        GameManager.Instance.OnScoreChanged += HandleScoreChanged;
        subscribed = true;

        HandleScoreChanged(GameManager.Instance.Score);
    }

    private void HandleScoreChanged(int newScore)
    {
        if (scoreText != null)
            scoreText.text = newScore.ToString();
    }
}