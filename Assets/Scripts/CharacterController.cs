using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;  // מונע סיבוב

    }

    void Update()
    {
        Move();
        Jump();
    }

    void Jump()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jumping!"); // הודעה להדפסת קפיצה
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // השתמש ב-velocity במקום linearVelocity
        }
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y); // השתמש ב-velocity במקום linearVelocity
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // הדמות נוגעת בקרקע
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // הדמות לא נוגעת בקרקע
        }
    }
}
