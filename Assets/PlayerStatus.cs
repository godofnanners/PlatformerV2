using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float currentHealth, maxHealth = 25;
    public float currentStamina, maxStamina = 50;
    public float currentMana, maxMana = 50;
    public bool running;

    void Update()
    {
        if (currentHealth <= 0)
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
    }

    public void AdjustHealth(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }

    public void AdjustMana(float amount)
    {
        currentMana += amount;
        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }
        if (currentMana < 0)
        {
            currentMana = 0;
        }
    }
}