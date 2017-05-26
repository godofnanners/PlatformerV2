using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : Projectile
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            other.SendMessageUpwards("Damage", damage);
           
        }
        else if (other.tag == "Platform")
        {
            Destroy(gameObject);
        }
    }
}
