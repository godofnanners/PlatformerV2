using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Magic : MonoBehaviour
{
    float nextCast;

    public virtual void Cast(GameObject projectileType, float manaCost, float cooldown)
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
        }
    }

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
}