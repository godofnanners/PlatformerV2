using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public int damage = 5;
    public float speed = 2;
    public float timer = 10;
    public float cooldown = 10;

    public Rigidbody2D rb;
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed * rb.velocity.x, speed * rb.velocity.y);

    }
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
            timer = cooldown;
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.SendMessageUpwards("AdjustHealth", -damage);
            Destroy(gameObject);
        }

        else if (other.tag == "Platform")
        {
            Destroy(gameObject);
        }
    }
}
