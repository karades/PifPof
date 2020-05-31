using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public AudioClip gunShot;
    public AudioClip bulletShell;
    public AudioSource gun;
    public AudioSource bullet;
    [SerializeField]
    public Transform firingPoint;

    public Rigidbody projectilePrefab;
    [SerializeField]
    float firingSpeed = 0.5f;

    private float lastTimeShot = 0.0f;
    public static Gun Instance;
     // Start is called before the first frame update
    void Awake()
    {
        Instance = GetComponent<Gun>();

    }
    private void Update()
    {

        if (Input.GetButton("Fire1"))
        {
            shoot();
        }
    }
   
    public void shoot()
    {
        if (lastTimeShot + firingSpeed <= Time.time)
        {
            gun.PlayOneShot(gunShot);
            StartCoroutine("waitShell");


            lastTimeShot = Time.time;
            Rigidbody instantiatedProjectile = Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation) as Rigidbody;

            Destroy(instantiatedProjectile, 2);
        }
    }
    private IEnumerator waitShell()
    {

        yield return new WaitForSeconds(0.3f);
        bullet.PlayOneShot(bulletShell);
    }
}
