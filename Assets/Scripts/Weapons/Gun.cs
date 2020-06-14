using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Gun : MonoBehaviour
{

    public AudioClip gunShot;
    public AudioClip bulletShell;
    public AudioSource gun;
    public AudioSource bullet;

    public Transform firingPoint;

    public Rigidbody projectilePrefab;
    public WeaponStats WeaponStats;


    private float lastTimeShot = 0.0f;
    public static Gun Instance;
     // Start is called before the first frame update
    void Awake()
    {
        Instance = GetComponent<Gun>();
    }
    private void Update()
    {
        if (WeaponStats.gunAmmo > 0)
        {
            if (Input.GetButton("Fire1"))
            {
                
                shoot();
      
            }
        }
    }
   
    public void shoot()
    {
        if (lastTimeShot + WeaponStats.gunFiringSpeed <= Time.time)
        {
            
            
                gun.PlayOneShot(gunShot);
                StartCoroutine("waitShell");


                lastTimeShot = Time.time;
                Rigidbody instantiatedProjectile = Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation) as Rigidbody;

                Destroy(instantiatedProjectile, 2);
                WeaponStats.gunAmmo--;

        }
    }
    private IEnumerator waitShell()
    {

        yield return new WaitForSeconds(0.3f);
        bullet.PlayOneShot(bulletShell);
    }
}
