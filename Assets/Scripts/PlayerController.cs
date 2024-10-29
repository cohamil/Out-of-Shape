using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 10f;
    private bool isFacingRight = true;
    public bool doubleJumpEnabled = false;
    private bool isDoubleJumping = false;

    private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded()) {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
            }
            else {
                if (doubleJumpEnabled && !isDoubleJumping)
                {
                    rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
                    isDoubleJumping = true;
                }
            }
            
        }

        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

    private bool IsGrounded()
    {
        // 0.2
        if (Physics2D.OverlapCircle(groundCheck.position, 0.7f, groundLayer)) {
            isDoubleJumping = false;
            return true;
        }
        return false;
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}