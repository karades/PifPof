using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    public AudioClip shotGunShot;
    public AudioSource shotgun;
    [SerializeField]
    public Transform firingPoint;

    public Rigidbody projectilePrefab;
    
    private float lastTimeShot = 0.0f;

    public WeaponStats weaponStats;

    public int BulletsShot; // Total bullets show per Shot of the gun
    public float BulletsSpread; // Degrees (0-360) to spread the Bullets

    // Start is called before the first frame update
    void Start()
    {


    }
    private void Update()
    {
        if (weaponStats.shotgunAmmo > 0)
        {
            if (Input.GetButton("Fire1"))
            {
                Shoot();
            }
        }
    }
    public void Shoot()
    {
        float TotalSpread = BulletsSpread / BulletsShot;
        if (lastTimeShot + weaponStats.shotgunFiringSpeed <= Time.time)
        {
            shotgun.PlayOneShot(shotGunShot);


            lastTimeShot = Time.time;
            for (int i = 0; i < BulletsShot; i++)
            {
                // Calculate angle of this bullet
                float spreadA = TotalSpread * (i + 1);
                float spreadB = BulletsSpread / 2.0f;
                float spread = spreadB - spreadA + TotalSpread / 2;
                float angle = firingPoint.rotation.eulerAngles.y;
                Quaternion rotation = Quaternion.Euler(new Vector3(0, (spread + angle), 0));

                Rigidbody instantiatedProjectile = Instantiate(projectilePrefab, firingPoint.position, rotation) as Rigidbody;
                Destroy(instantiatedProjectile, 2);
                
            }
            weaponStats.shotgunAmmo--;
           
        }
    }

}
