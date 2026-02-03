using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public event Action<int> OnScoreChanged;
    public event Action OnGameOver;

    public int Score { get; private set; } = 0;
    public bool IsGameOver { get; private set; } = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void AddScore(int amount)
    {
        if (IsGameOver) return;

        Score += amount;
        OnScoreChanged?.Invoke(Score);
    }

    public void TriggerGameOver()
    {
        if (IsGameOver) return;

        IsGameOver = true;
        OnGameOver?.Invoke();

        Time.timeScale = 0f;
    }
}