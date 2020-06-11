using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    public int gunAmmo;
    public int maxGunAmmo = 30;
    public float gunFiringSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        gunAmmo = maxGunAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
