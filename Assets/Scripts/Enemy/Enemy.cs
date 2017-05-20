using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rigidB;
    Transform frontPoint;
    public LayerMask targetGround;
    public bool facingRight;
    public float speed;
    
    void Start ()
    {
        rigidB = GetComponent<Rigidbody2D>();
        frontPoint = transform.Find("FirePoint");
        facingRight = true;
    }
	
	void Update ()
    {
        CheckAhead();
        Move();
	}

    void Flip()
    {
        if (facingRight)
        {
            facingRight = false;
        }
        else
        {
            facingRight = true;
        }

        transform.localScale *= -1;
    }
    public void CheckAhead()
    {

        Vector2 frontPointPos = new Vector2(frontPoint.position.x, frontPoint.position.y);
        Vector2 dir;
        if (facingRight)
        {
            dir = new Vector2(0.5f, -0.5f);
        }
        else
        {
            dir = new Vector2(-0.5f, -0.5f);
        }
        RaycastHit2D chk = Physics2D.Raycast(frontPointPos, dir, 0.27f, targetGround);
        if (chk.collider == null || chk.collider.tag == "Enemy")
        {
            Flip();       
        }
        else
        {
            Debug.DrawLine(frontPointPos, chk.point, Color.red);           
        }    
    }
    public void Move()
    {
        if (facingRight)
        {
            rigidB.velocity = new Vector2(speed, rigidB.velocity.y);
        }
        else
        {
            rigidB.velocity = new Vector2(speed * -1, rigidB.velocity.y);
        }
    }
}
