using UnityEngine;

public class Mushroom_NguyenThanhVinh : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player_NguyenThanhVinh"))
        {
            Move_NguyenThanhVinh mario = other.GetComponent<Move_NguyenThanhVinh>();
            if (mario != null)
            {
                mario.BecomeBig(); 
            }

            Destroy(gameObject); 
        }
    }
}
