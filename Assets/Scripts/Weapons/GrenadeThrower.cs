using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    public float throwForce = 40;
    public GameObject Grenade;
    public WeaponStats weaponStats;
    // Update is called once per frame
    void Update()
    {
        if (weaponStats.grenadeAmmo > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ThrowGrenade();
            }
        }
    }
    void ThrowGrenade()
    {
        GameObject gr = Instantiate(Grenade, transform.position, transform.rotation);
        Rigidbody rb = gr.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce,ForceMode.VelocityChange);
        weaponStats.grenadeAmmo--;
    }
}
