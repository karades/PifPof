using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelControl : MonoBehaviour
{
    public float basicEnemyCount = 6;
    private float basicCount = 6;
    public float levelCount = 1;
    public SpawnEnemy spawnEnemy;

    // Start is called before the first frame update
    void Start()
    {
        spawnEnemy = GetComponent<SpawnEnemy>();
        spawnEnemy.counter = basicEnemyCount;
    }

    // Update is called once per frame
    void Update()
    {
        CheckEnemyExist();
    } 
    void CheckEnemyExist() 
    {
        if (spawnEnemy.destroyed == basicEnemyCount)
        {
            if (spawnEnemy.counter == 0)
            {
                levelCount++;
                basicEnemyCount = basicEnemyCount + basicCount + 1;
                spawnEnemy.counter = basicEnemyCount;
                spawnEnemy.destroyed = 0;
                waitNextLevel();
            }
        }
        
    }
    public float getLevel()
    {
        return levelCount;
    }
    private IEnumerator waitNextLevel()
    {
        
        yield return new WaitForSeconds(1.0f);
        
    }
}
