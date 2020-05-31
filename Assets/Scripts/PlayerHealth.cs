using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float maxHealth = 100.0f;
    public float currentHealth;
    public GameObject LoseMenu;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        CheckHP(currentHealth);
    }
    void TakeDamage(float hp)
    {
        currentHealth -= hp;
        healthBar.SetHealth(currentHealth);
    }
    void CheckHP(float currentHealth)
    {
        if (currentHealth <= 0.0f)
        {
            LoseMenu.SetActive(true);
        }
    }
}
