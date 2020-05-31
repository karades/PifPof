using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{

    public float maxHealth = 100.0f;
    public float currentHealth;
    public HealthBar healthBar;
    private NavMeshAgent Enemy;
    public GameObject spawn;

    void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("Spawner");
        Enemy = GetComponent<NavMeshAgent>();
        currentHealth= maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            spawn.GetComponent<SpawnEnemy>().SendMessage("addDestroyed");
        }
    }

    public void TakeDamage(float hp)
    {
        currentHealth -= hp;
        healthBar.SetHealth(currentHealth);
    }

}
