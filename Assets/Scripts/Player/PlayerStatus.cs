using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerStatus : MonoBehaviour
{
    public float currentHealth, maxHealth = 25;
    public float currentMana, maxMana = 50;
    public Slider Healthbar;
    public Slider Manabar;

    private void Start()
    { 
        Healthbar.maxValue = maxHealth;
        Manabar.maxValue = maxMana;
    }

    void Update()
    {
       
        
        

        Healthbar.value = currentHealth;
        Manabar.value = currentMana;
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
            SceneManager.LoadScene("Level 1");
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