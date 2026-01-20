using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private GameObject newText;
    [SerializeField] private GameObject panel;

    void Start()
    {
        panel.SetActive(false);
        newText.SetActive(false);
    }
    
    public void SetEndPanel(float score, float highScore, bool isNewHighScore)
    {
        panel.SetActive(true);
        
        scoreText.text = $"{score}";
        highScoreText.text = $"{highScore}";
        
        if(isNewHighScore) newText.SetActive(true);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
