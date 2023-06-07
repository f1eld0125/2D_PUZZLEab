using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;
    private bool canJump = true;

    // private로 변수 만들고
    public float maxSpeed = 50.0f;
    public float jumpForce = 150.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
        // start시 가져오기
    }

    void Update()
    {
        //움직임
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            animator.SetBool("isWalking", true);
            sr.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            animator.SetBool("isWalking", true);
            sr.flipX = true;
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        rb.AddForce(Input.GetAxisRaw("Horizontal") * Vector2.right);

        if (Mathf.Abs(rb.velocity.x) >= maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed * Mathf.Sign(rb.velocity.x), rb.velocity.y);
        }

        //점프
        if (CheckGround())
        {
            animator.SetBool("isJumping", false);
        }

        if (Input.GetAxisRaw("Vertical") > 0 && CheckGround() && canJump)
        {
            StartCoroutine(JumpDelay());
            animator.SetBool("isJumping", true);

            rb.AddForce(Vector2.up * jumpForce);
        }
    }

    public bool CheckGround()
    {
        float distanceToTheGround = GetComponent<Collider2D>().bounds.extents.y;
        return Physics2D.Raycast(
            transform.position,
            Vector2.down,
            distanceToTheGround + 0.05f,
            LayerMask.GetMask("Floor")
        );
    }

    IEnumerator JumpDelay()
    {
        canJump = false;
        yield return new WaitForSeconds(0.5f);
        canJump = true;
    }
}
