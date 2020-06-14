using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    public AudioClip machineGunShot;
    public AudioClip machineBulletShell;
    public AudioSource machineGun;
    public AudioSource machineBullet;
    [SerializeField]
    public Transform firingPoint;

    public Rigidbody projectilePrefab;
    public WeaponStats WeaponStats;
    [SerializeField]

    private float lastTimeShot = 0.0f;
    public static MachineGun Instance;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = GetComponent<MachineGun>();

    }

    private void Update()
    {
        if (WeaponStats.machineGunAmmo > 0)
        {
            if (Input.GetButton("Fire1"))
            {
                shoot();
            }
        }
    }
    public void shoot()
    {
        if (lastTimeShot + WeaponStats.machineGunFiringSpeed <= Time.time)
        {
            machineGun.PlayOneShot(machineGunShot);
            StartCoroutine("waitMachineShell");


            lastTimeShot = Time.time;
            Rigidbody instantiatedProjectile = Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation) as Rigidbody;

            Destroy(instantiatedProjectile, 2);
            WeaponStats.machineGunAmmo--;
        }
    }
    private IEnumerator waitMachineShell()
    {

        yield return new WaitForSeconds(0.3f);
        machineBullet.PlayOneShot(machineBulletShell);
    }
}
