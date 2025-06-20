using UnityEngine;

public class EnemyMove_NguyenThanhVinh : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool movingRight = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.linearVelocity = new Vector2((movingRight ? 1 : -1) * moveSpeed, rb.linearVelocity.y);

        // Kiểm tra phía trước còn nền không
        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, checkRadius, groundLayer);

        if (!groundInfo.collider)
        {
            Flip();
        }
    }

    void Flip()
    {
        movingRight = !movingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
