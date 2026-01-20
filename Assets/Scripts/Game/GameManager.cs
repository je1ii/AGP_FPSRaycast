using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private EndGame end;
    [SerializeField] private ScoreText score;
    
    void Start()
    {
        Instance = this;
    }

    public void GameEnding()
    {
        float s = score.FetchScore();
        bool isHighScoreNew = HighScoreManager.CheckNewHighScore(s);

        float hs = HighScoreManager.FetchHighScore();
        
        if (isHighScoreNew)
        {
            Debug.Log("New High Score");
            end.SetEndPanel(s, hs, true);
        }
        else
        {
            end.SetEndPanel(s, hs, false);
        }
    }
}
