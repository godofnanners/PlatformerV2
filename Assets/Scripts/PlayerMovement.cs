using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rigidB;
    public float acceleration;
    public float jumpForce;
    public LayerMask targetGround;
    Transform groundCheck;
    bool isGrounded = false;
    // Use this for initialization
    void Start ()
    {
        groundCheck = transform.FindChild("GroundCheck");
        rigidB = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckGrounded();
        Jump();
        Move();
        rigidB.velocity = Vector2.right * acceleration * Time.deltaTime;
        
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (acceleration > -100)
            {
                acceleration -= 20;
            }


        }
        if (Input.GetKey(KeyCode.D))
        {
            if (acceleration < 100)
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
            rigidB.AddForce(new Vector2(0,jumpForce));
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
