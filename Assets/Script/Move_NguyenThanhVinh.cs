using UnityEngine;
using UnityEngine.SceneManagement;

public class Move_NguyenThanhVinh : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    public GameOverMenu_NguyenThanhVinh gameOverMenu;
    public RuntimeAnimatorController bigAnimator;    
    public RuntimeAnimatorController smallAnimator;  

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded = false;
    private bool isDead = false;
    private bool isBig = false; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        
        if (smallAnimator != null)
        {
            animator.runtimeAnimatorController = smallAnimator;
        }
    }

    void Update()
    {
        if (isDead) return;

        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        
        if (moveInput > 0)
            transform.localScale = new Vector3(1, transform.localScale.y, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, transform.localScale.y, 1);

        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

       
        bool isSliding = Input.GetKey(KeyCode.LeftShift) && Mathf.Abs(moveInput) > 0.1f;

        
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
        animator.SetBool("isJumping", !isGrounded);
        animator.SetBool("isSliding", isSliding);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground_NguyenThanhVinh"))
        {
            isGrounded = true;
        }

        
        if (collision.gameObject.CompareTag("Enemy_NguyenThanhVinh") && !isDead)
        {
            Vector2 normal = collision.contacts[0].normal;

            if (Vector2.Dot(normal, Vector2.up) > 0.5f)
            {
                Animator enemyAnim = collision.gameObject.GetComponent<Animator>();
                if (enemyAnim != null)
                {
                    enemyAnim.SetTrigger("death");
                    Destroy(collision.gameObject, 0.5f);
                }

                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce / 1.5f);
            }
            else
            {
                if (isBig)
                {
                    BecomeSmall(); 
                }
                else
                {
                    isDead = true;
                    animator.SetTrigger("death");

                    rb.linearVelocity = Vector2.zero;
                    rb.bodyType = RigidbodyType2D.Kinematic;
                    GetComponent<Collider2D>().enabled = false;

                    Invoke("TriggerGameOverUI", 1f);
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground_NguyenThanhVinh"))
        {
            isGrounded = false;
        }
    }

    void TriggerGameOverUI()
    {
        gameOverMenu.ShowGameOver();
    }

    
    public void BecomeBig()
    {
        if (!isBig)
        {
            isBig = true;

            transform.localScale = new Vector3(transform.localScale.x, 1.5f, 1f);
            animator.runtimeAnimatorController = bigAnimator;
            animator.SetTrigger("grow");

            BoxCollider2D box = GetComponent<BoxCollider2D>();
            if (box != null)
            {
                box.size = new Vector2(1f, 2f);
                box.offset = new Vector2(0f, 1f);
            }
        }
    }

    
    void BecomeSmall()
    {
        isBig = false;

        transform.localScale = new Vector3(transform.localScale.x, 1f, 1f);
        animator.runtimeAnimatorController = smallAnimator; 
        animator.SetTrigger("shrink"); 

        BoxCollider2D box = GetComponent<BoxCollider2D>();
        if (box != null)
        {
            box.size = new Vector2(1f, 1f);
            box.offset = new Vector2(0f, 0.5f);
        }
    }
}
