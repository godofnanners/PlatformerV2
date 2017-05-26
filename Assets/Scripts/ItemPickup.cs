using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public bool health, mana;
    public int Amount;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Pickup(other);
        }
    }

    void Pickup(Collider2D other)
    {
        if (health && other.GetComponent<PlayerStatus>().currentHealth < other.GetComponent<PlayerStatus>().maxHealth)
        {
            other.GetComponent<PlayerStatus>().AdjustHealth(Amount);
            Destroy(gameObject);
        }
        if (mana && other.GetComponent<PlayerStatus>().currentMana < other.GetComponent<PlayerStatus>().maxMana)
        {
            other.GetComponent<PlayerStatus>().AdjustMana(Amount);
            Destroy(gameObject);
        }
    }
}
