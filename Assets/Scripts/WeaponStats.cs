using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    public int currentAmmo;
    public int currentGun;
    public int gunAmmo;
    public int maxGunAmmo = 30;
    public float gunFiringSpeed = 0.5f;

    public int machineGunAmmo;
    public int maxMachineGunAmmo = 30;
    public float machineGunFiringSpeed = 0.1f;

    public int shotgunAmmo;
    public int maxShotgunAmmo = 30;
    public float shotgunFiringSpeed = 0.2f;

    public int grenadeAmmo;
    public int maxGrenadeAmmo = 5;

    // Start is called before the first frame update
    void Start()
    {
        gunAmmo = maxGunAmmo;
        machineGunAmmo = maxMachineGunAmmo;
        shotgunAmmo = maxShotgunAmmo;
        grenadeAmmo = maxGrenadeAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        setCurrentAmmo(currentGun);
    }
    public void setCurrentAmmo(int id)
    {
        switch (id)
        {
            case 1:
                currentAmmo = gunAmmo;
                break;
            case 2:
                currentAmmo = machineGunAmmo;
                break;
            case 3:
                currentAmmo = shotgunAmmo;
                break;
            case 4:
                currentAmmo = grenadeAmmo;
                break;
            default:
                break;
        }

    }
}
