using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;
    private bool canJump = true;
    public float maxSpeed = 10.0f;
    public float moveSpeed = 1.0f;
    public float jumpForce = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move
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

        rb.AddForce(Input.GetAxisRaw("Horizontal") * Vector2.right * moveSpeed * Time.deltaTime);

        if (Mathf.Abs(rb.velocity.x) >= maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed * Mathf.Sign(rb.velocity.x), rb.velocity.y);
        }

        bool checkGround = CheckGround();
        if (checkGround && canJump)
        {
            animator.SetBool("isJumping", false);
        }

        // Jump
        if (Input.GetAxisRaw("Vertical") > 0 && checkGround && canJump)
        {
            StartCoroutine(JumpDelay());
            animator.SetBool("isJumping", true);
            rb.AddForce(Vector2.up * jumpForce);
        }
    }

    public bool CheckGround()
    {
        float distanceToTheGround = GetComponent<Collider2D>().bounds.extents.y;
        // var hit = Physics2D.BoxCast(
        //     new Vector2(transform.position.x, transform.position.y - distanceToTheGround),
        //     new Vector2(1f,distanceToTheGround + 0.01f),
        //     0f,
        //     Vector2.down,
        //     0f,
        //     LayerMask.GetMask("Floor"),

        // );
        var hit = BoxCastDrawer.BoxCastAndDraw(
            new Vector2(transform.position.x, transform.position.y - distanceToTheGround),
            new Vector2(0.9f,distanceToTheGround + 0.01f),
            0f,
            Vector2.down,
            0f,
            LayerMask.GetMask("Floor")

        );
        return hit;
    }

    

    IEnumerator JumpDelay()
    {
        canJump = false;
        yield return new WaitForSeconds(0.7f);
        canJump = true;
    }

     
}
