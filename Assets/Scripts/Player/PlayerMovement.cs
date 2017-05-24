using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidB;
    float acceleration;
    float maxSpeed = 250;
    public float jumpForce;
    public LayerMask targetGround;
    Transform groundCheck;
    public bool isGrounded = false;
    public bool facingRight = true;
    // Use this for initialization
    void Start()
    {
        groundCheck = transform.Find("GroundCheck");
        rigidB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        CheckGrounded();

    }
    void FixedUpdate()
    {
        Jump();
        Move();
        rigidB.velocity = new Vector2(acceleration * Time.deltaTime, rigidB.velocity.y);
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            facingRight = false;
            if (acceleration > -maxSpeed)
            {
                acceleration -= 20;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            facingRight = true;
            if (acceleration < maxSpeed)
            {
                acceleration += 20;
            }
        }
        if (acceleration < 0 || acceleration > 0)
        {
            acceleration += Mathf.Sign(acceleration) * -4;
        }

    }

    public void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rigidB.AddForce(new Vector2(0, jumpForce));
            isGrounded = false;
        }
    }

    public void CheckGrounded()
    {

        Vector2 groundCheckPos = new Vector2(groundCheck.position.x, groundCheck.position.y);
        RaycastHit2D chk = Physics2D.Raycast(groundCheckPos, Vector2.down, 0.17f, targetGround);
        if (chk.collider != null)
        {
            isGrounded = true;
            Debug.DrawLine(groundCheckPos, chk.point, Color.red);
        }
        else
        {
            isGrounded = false;
        }

    }
}