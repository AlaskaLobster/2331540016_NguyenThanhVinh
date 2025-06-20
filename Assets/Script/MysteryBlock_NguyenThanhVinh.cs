using UnityEngine;

public class MysteryBlock_NguyenThanhVinh : MonoBehaviour
{
    public GameObject coinPrefab;
    public Transform spawnPoint;
    private bool isUsed = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isUsed) return;

        if (collision.gameObject.CompareTag("Player_NguyenThanhVinh"))
        {
            Vector2 normal = collision.contacts[0].normal;
            if (Vector2.Dot(normal, Vector2.up) > 0.5f)
            {
                isUsed = true;
                Instantiate(coinPrefab, spawnPoint.position, Quaternion.identity);
            }
        }
    }
}
