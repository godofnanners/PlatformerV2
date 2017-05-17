using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public GameObject bullet;
    Transform groundCheck;

    public float timer = 0.5f;
    public float cooldown = 0.5f;

    private PlayerMovement playerMove;
    bool facingRight;
	// Use this for initialization
	void Start () 
    {
        playerMove = this.GetComponent<PlayerMovement>();
        facingRight = playerMove.facingRight;
        groundCheck = transform.FindChild("GroundCheck");
	}
	
	// Update is called once per frame
	void Update () 
    {
        Shoot();
	}
    void Shoot()
    {
        if (timer < 0)
        {
            timer = 0;
        }
        timer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.F) && timer <= 0)
        {
            facingRight = playerMove.facingRight;
            GameObject newBullet = Object.Instantiate(bullet, groundCheck.position, transform.rotation) as GameObject;
            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            Vector2 fireDirection;
            if (facingRight)
            {
                fireDirection = Vector2.right;
            }
            else
            {
                fireDirection = Vector2.left;
            }
            //Vector2 fireDirection = target.transform.position - groundCheck.position;
            //fireDirection.Normalize();
            rb.velocity = fireDirection;
            timer = cooldown;
        }
            
    
    }
}
