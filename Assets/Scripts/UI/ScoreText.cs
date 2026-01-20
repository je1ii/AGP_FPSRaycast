using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private float score;
    
    void Start()
    {
        score = 0;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        float roundedScore = RoundToTwoDecimals(score);
        scoreText.text = $"{roundedScore}";
    }
    
    private float RoundToTwoDecimals(float value)
    {
        float result = Mathf.Round(value * 100f) / 100f;
        return result;
    }

    public void AddScore(float points)
    {
        score += points;
        UpdateScoreUI();
    }
    
    public float FetchScore() => RoundToTwoDecimals(score);
}
