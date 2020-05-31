using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{

    public float delay = 3.0f;
    public float BlastRadius = 5.0f;
    public float force = 1000.0f;
    private float countdown;
    public GameObject explosionEffect;

    bool hasExploded = false;
    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f&& !hasExploded)
        {
            hasExploded = true;
            Explode();
        }
    }
    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, BlastRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb!= null){
                rb.AddExplosionForce(force, transform.position, BlastRadius);
            }
            BasicEnemy enemy = nearbyObject.GetComponent<BasicEnemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(50);
            }
            EnemyFollow enemy2 = nearbyObject.GetComponent<EnemyFollow>();
            if(enemy2 != null)
            {
                enemy2.addForceToEnemy();
            }
        }
        Destroy(gameObject);
    }
}
