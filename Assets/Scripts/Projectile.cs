using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public float damage, timer, projectileLife, speed;

    Rigidbody2D rb;

    public virtual void Update()
    {
        DestroyProjectile(gameObject);
    }

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed * rb.velocity.x, speed * rb.velocity.y);
    }

    public virtual void DestroyProjectile(GameObject gameObject)
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
            timer = projectileLife;
        }
    }
}
