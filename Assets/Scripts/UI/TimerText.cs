using UnityEngine;
using TMPro;

public class TimerText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float gameTimer = 10f;

    private bool canTimerRun = true;
    void Update()
    {
        if (canTimerRun) gameTimer -= Time.deltaTime;
        DisplayTime(gameTimer);
        
        if (gameTimer <= 0)
        {
            canTimerRun = false;
            GameManager.Instance.GameEnding();
        }
    }
    
    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1; 

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}
