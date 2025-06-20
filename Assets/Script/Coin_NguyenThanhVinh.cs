using UnityEngine;

public class Coin_NguyenThanhVinh : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player_NguyenThanhVinh"))
        {
            ScoreManager_NguyenThanhVinh score = FindObjectOfType<ScoreManager_NguyenThanhVinh>();
            if (score != null)
            {
                score.AddScore();
            }

            Destroy(gameObject);
        }
    }
}
