using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour {

    public int damage = 5;
    public float speed = 5;
    public float timer = 10;
    public float cooldown = 10;

    public Rigidbody2D rb;

	// Use this for initialization
	void Start () 
    {

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed * rb.velocity.x, speed * rb.velocity.y);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.SendMessageUpwards("Damage", damage);
            Destroy(gameObject);
        }

        else if (other.tag == "Platform")
        {
            Destroy(gameObject);
        }
    }
}
