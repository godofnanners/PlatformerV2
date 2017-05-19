using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Magic : MonoBehaviour
{
    float nextCast;
    float timer = 10000;

    public virtual bool CheckCast(ref float currentMana, float cooldown, float manaCost)
    {
        if (Time.time > nextCast)
        {
            if (currentMana >= manaCost)
            {
                currentMana -= manaCost;

                nextCast = Time.time + cooldown;

                return true;
            }
        }
        return false;
    }

    public virtual void Cast(GameObject projectileType, float manaCost, float cooldown, float projectileLife)
    {
        if (CheckCast(ref GetComponent<PlayerStatus>().currentMana, cooldown, manaCost))
        {
            GameObject projectile = Object.Instantiate(projectileType, transform.position, transform.rotation) as GameObject;
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            if (GetComponent<PlayerMovement>().facingRight)
            {
                rb.velocity = Vector2.right;
            }
            else
            {
                rb.velocity = Vector2.left;
            }
            DestroyProjectile(projectile, projectileLife);
        }
    }

    public virtual void DestroyProjectile(GameObject gameObject, float projectileLife)
    {
        timer = projectileLife;
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Destroy(gameObject);
            timer = projectileLife;
        }
    }
}