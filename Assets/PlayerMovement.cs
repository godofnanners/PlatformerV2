using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rigidB;
    public float acceleration;
	// Use this for initialization
	void Start ()
    {

        rigidB = GetComponent<Rigidbody2D>();


	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
        rigidB.velocity = Vector2.right * acceleration * Time.deltaTime;
        Jump();
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (acceleration > -100)
            {
                acceleration -= 10;
            }


        }
        if (Input.GetKey(KeyCode.D))
        {
            if (acceleration < 100)
            {
                acceleration += 10;
            }
        }
        
    }

    public void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidB.AddForce(new Vector2(0,1000));
        }
    }
}
