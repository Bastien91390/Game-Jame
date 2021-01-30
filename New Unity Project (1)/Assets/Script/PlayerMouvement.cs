using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    public float BasicMove;
    public float jumpForce;

    private bool isJumping;
    private bool isgrounded;

    public Transform groundleft;
    public Transform groundrigth;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        isgrounded = Physics2D.OverlapArea(groundleft.position, groundrigth.position);

        float horizontalMov = Input.GetAxis("Horizontal") * BasicMove * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isgrounded)
        {
            isJumping = true;
        }

        Move(horizontalMov);
    }

    void Move(float _horizontalMov)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMov, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }
}