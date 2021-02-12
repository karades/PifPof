using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public WeaponStats weaponStats;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float respawnTime=5;
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
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(resetAmmo());
        }
    }
    IEnumerator resetAmmo()
    {
        yield return new WaitForSeconds(respawnTime);
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider>().enabled = true;

    }
    void Rotate(float speed)
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
