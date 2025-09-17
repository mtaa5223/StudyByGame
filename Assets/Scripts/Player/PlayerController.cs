using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpVelocity = 7f;
    public int maxJumps = 2;

    [Header("Components")]
    public Animator animator;
    public BoxCollider2D playerCollider;

    private Rigidbody2D rb;
    public bool isGrounded;
    public int jumpCount;

    // 슬라이드 관련
    private Vector2 standingSize;
    private Vector2 slidingSize;
    private Vector2 standingOffset;
    private Vector2 slidingOffset;

    [Header("Sliding Settings")]
    public float slideHeightFactor = 0.5f; // 서 있는 높이 대비 슬라이드 높이 비율

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerCollider = GetComponent<BoxCollider2D>();

        // 점프 초기화
        jumpCount = 0;

        // 콜라이더 기본값 저장
        standingSize = playerCollider.size;
        standingOffset = playerCollider.offset;

        // 슬라이드용 콜라이더 계산
        slidingSize = new Vector2(standingSize.x, standingSize.y * slideHeightFactor);
        // offset.y는 아래쪽이 고정되므로 변화 없음
        slidingOffset = standingOffset;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            jumpCount++;
            Jump();
        }
        Slide();
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpVelocity);
        if (jumpCount == 0)
        {
            animator.SetTrigger("Run");
        }
        if (jumpCount == 1)
        {
            animator.SetTrigger("OneJump");
        }
        if (jumpCount == 2)
        {
            animator.SetTrigger("DoubleJump");
        }
    }

    void Slide()
    {
        if (isGrounded && Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("Slide", true);
            playerCollider.size = slidingSize;
            playerCollider.offset = slidingOffset;
            transform.position = new Vector2(transform.position.x, -0.578f);
        }
        else
        {
            animator.SetBool("Slide", false);
            playerCollider.size = standingSize;
            playerCollider.offset = standingOffset;
        }
    }

    // 땅 체크 (간단 예시)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0; // 땅에 닿으면 점프 횟수 초기화
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
