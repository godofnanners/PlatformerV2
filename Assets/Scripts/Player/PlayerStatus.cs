using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerStatus : MonoBehaviour
{
    public float currentHealth, maxHealth = 25;
    public float currentStamina, maxStamina = 50;
    public float currentMana, maxMana = 50;
    public bool running;
    public Slider Healthbar;
    public Slider Manabar;
    public Slider Staminabar;

    private void Start()
    {
        Healthbar.maxValue = maxHealth;
        Manabar.maxValue = maxMana;
        Staminabar.maxValue = maxStamina;
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Level 1");
        }
        if (running)
        {
            currentStamina -= 5;
        }
        if (!running && currentStamina < maxStamina)
        {
            currentStamina += 1;
        }

        currentMana += 0.05f;

        Healthbar.value = currentHealth;
        Manabar.value = currentMana;
        Staminabar.value = currentStamina;

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