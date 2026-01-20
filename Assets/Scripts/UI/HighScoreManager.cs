using UnityEngine;

public static class HighScoreManager
{
    private static float currentHighScore;
    
    public static float FetchHighScore() => Mathf.Round(currentHighScore * 100f) / 100f;

    public static bool CheckNewHighScore(float score)
    {
        if (score > currentHighScore)
        {
            currentHighScore = score;
            return true;
        }
        return false;
    }
}
