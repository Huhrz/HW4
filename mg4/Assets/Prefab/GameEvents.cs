using System;

public static class GameEvents
{
    public static Action OnFlap;
    public static Action OnPlayerDied;
    public static Action<int> OnScoreChanged;   // new score
    public static Action OnPointScored;         // for audio ping
}