using UnityEngine;
using TMPro;

public class ScoreManager_NguyenThanhVinh : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    private int coinValue = 1 + 6; 

    public void AddScore()
    {
        score += coinValue;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score.ToString();
    }
}
