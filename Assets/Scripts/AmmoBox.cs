using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditor;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public WeaponStats weaponStats;
    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        weaponStats = GameObject.Find("WeaponStats").GetComponent<WeaponStats>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate(speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("triggered");
        if(other.tag == "Player")
        {
            weaponStats.refreshAmmo();
            Destroy(gameObject); ;
        }
    }
    void Rotate(float speed)
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
