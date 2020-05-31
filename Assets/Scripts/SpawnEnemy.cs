using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float counter;
    private float timer= 0.0f;
    public float destroyed = 0;
    private Transform spawner;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (counter > 0)
        {
            timer += Time.deltaTime;
            if (timer >= 0.5f)
            {
                if (Random.value < 0.5) 
                {
                    GameObject newEnemy = Instantiate(EnemyPrefab); 
                }
                else
                {
                    GameObject newEnemy = Instantiate(EnemyPrefab, new Vector3(spawner.position.x,spawner.position.y,-spawner.position.z),spawner.rotation);
                }
                
                timer = 0;
                counter--;
            }
        }
        
    }
    public void addDestroyed()
    {
        destroyed++;
    }
}
