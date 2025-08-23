using UnityEngine;

public class PlayerJump2D : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpVelocity = 7f;   // 점프 속도
    public int maxJumps = 2;          // 최대 점프 횟수 (2단 점프)

    private int jumpCount;            // 현재 점프 횟수
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            Jump();
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Slide();
        }
        else
        {
            Idle();   
        }
    }
    void Idle()
    {
        rb.gravityScale = 1;
    }
    void Jump()
    {
        // 속도를 바로 설정 (중첩 점프 시 쭉 올라가는 문제 해결)
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpVelocity);

        jumpCount++;
    }
    void Slide()
    {
        rb.gravityScale = 3;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                jumpCount = 0;
                break;
            }
        }
    }
}
