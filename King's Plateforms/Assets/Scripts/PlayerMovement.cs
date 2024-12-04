using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private bool isJumping;
    private bool isGrounded;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if(Input.GetButtonDown("Jump") && isGrounded==true)
        {
            isJumping = true;
        }

        MovePlayer(horizontalMovement);

        Flip(rb.linearVelocity.x);

        float charcterVelocity = Mathf.Abs(rb.linearVelocity.x);
        animator.SetFloat("Speed", charcterVelocity);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVeloctity = new Vector2(_horizontalMovement, rb.linearVelocity.y);
        rb.linearVelocity = Vector3.SmoothDamp(rb.linearVelocity, targetVeloctity, ref velocity, .05f);

        if(isJumping == true )
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping=false;
        }
    }

    void Flip(float _velocity)
    {
        if(_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }else if(_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
}
