using UnityEngine;
using System.Collections;

public class Bullet : Projectile
{
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
