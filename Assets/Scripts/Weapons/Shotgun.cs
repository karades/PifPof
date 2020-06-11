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
    [SerializeField]
    float firingSpeed = 0.2f;

    private float lastTimeShot = 0.0f;
    public static Shotgun Instance;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = GetComponent<Shotgun>();

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
            shotgun.PlayOneShot(shotGunShot);


            lastTimeShot = Time.time;
            for (float t = -0.02f; t <= 0.02 ; t += 0.02f)
            { 
                Rigidbody instantiatedProjectile = Instantiate(projectilePrefab, firingPoint.position-new Vector3(0,0,t), firingPoint.rotation*Quaternion.Euler(0,t*300,0)) as Rigidbody;
                Destroy(instantiatedProjectile, 2);
            }
           
        }
    }

}
