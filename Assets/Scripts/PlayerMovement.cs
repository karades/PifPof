using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5.0f;
    public Rigidbody player;
    public float gravity = 6.0f;
    private float doubleSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        handleRotationInput();
        handleMovement();

    }

  
    void handleMovement()
    {
        float moveHorizontal = Input.GetAxis("Vertical");
        float moveVertical = -Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal * speed * Time.deltaTime, 0.0f, moveVertical * speed * Time.deltaTime);
        Vector3 gravitation = new Vector3(0.0f, -gravity * speed * Time.deltaTime, 0.0f);
        player.transform.Translate(movement, Space.World);
        player.AddForce(gravitation);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = doubleSpeed;
        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            speed = 5.0f;
        }

    }
    void handleRotationInput()
    {
        RaycastHit hit;
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(_ray,out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="Enemy")
        {
            Vector3 dir = collision.contacts[0].point - transform.position;
            SendMessage("TakeDamage", 25.0f);
            dir = -dir.normalized;
            player.AddRelativeForce(dir * 20.0f , ForceMode.Impulse);

        }
    }
}