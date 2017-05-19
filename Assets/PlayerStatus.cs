using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float health = 25;
    public float currentStamina, maxStamina = 50;
    public float currentMana, maxMana = 50;
    public bool running;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (running)
        {
            currentStamina -= 1;
        }
        if (!running && currentStamina < maxStamina)
        {
            currentStamina += 1;
        }
        if (currentMana < maxMana)
        {
            currentMana += 1;
        }
    }
    public void Damage(float damage)
    {
        health -= damage;
    }
}
