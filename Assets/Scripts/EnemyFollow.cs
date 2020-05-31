using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    private NavMeshAgent EnemyNav;

    public GameObject Player;

    public bool bIsOnTheMove = false;

    private float speed = 5.0f;
    private float gravity = 6.0f;
    private bool updateOn = true;
    private float groundDistance = 0.5f;


    public float EnemyDistanceRun = 4.0f;
    public float GunDamage = 25.0f;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        EnemyNav = GetComponent<NavMeshAgent>();
        GetComponent<NavMeshAgent>().enabled = false;
    }


    void FixedUpdate()
    {

        if (updateOn == true)
        {
            addForceToEnemy();
        }
    }
    private void OnCollisionEnter(Collision bullet)
    {
        if (bullet.gameObject.tag == "Bullet" || (bullet.gameObject.name == "Grenade(Clone)"))
        {
            TurnOff();

            Vector3 dir = bullet.contacts[0].point - transform.position;
            SendMessage("TakeDamage",GunDamage);    
            dir = -dir.normalized;
            GetComponent<Rigidbody>().AddRelativeForce(dir * 25.0f,ForceMode.Impulse);

            Debug.Log("Hit");
            StartCoroutine(updateOff());

        }
    }
    public void addForceToEnemy()
    {
        speed = GetComponent<Rigidbody>().velocity.magnitude;
        //Debug.Log(IsGrounded());
        if (!IsGrounded())
        {
            TurnOff();

        }
        Vector3 gravitation = new Vector3(0.0f, -gravity * speed * Time.deltaTime, 0.0f);
        GetComponent<Rigidbody>().AddForce(gravitation);



        if (IsGrounded() && speed <= 0.25f)
        {
            TurnOn();
            Follow();
        }
    }
    void TurnOff()
    {
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = false;
    }
    void TurnOn()
    {
        GetComponent<NavMeshAgent>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = true;
    }
    void Follow()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        if (distance < EnemyDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - Player.transform.position;

            Vector3 newPos = transform.position - dirToPlayer;

            EnemyNav.SetDestination(newPos);
            
        }
    }
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, groundDistance + 0.1f);
    }

    private IEnumerator updateOff()
    {
        updateOn = false;
        yield return new WaitForSeconds(0.25f);
        updateOn = true;
    }
}
