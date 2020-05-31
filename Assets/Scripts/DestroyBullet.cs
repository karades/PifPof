using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{

    public float speed = 20f;
    // Use this for initialization
    void Awake()
    {

        transform.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(speed, 0, 0));
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }


}
