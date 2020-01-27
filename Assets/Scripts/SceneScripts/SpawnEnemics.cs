using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemics : MonoBehaviour
{

    public int enemyNumber;
    public float respawnDistance;
    public int respawnTime;
    public GameObject enemyTypePrefab;
    private GameObject enemyToSpawn;

    private double countSpawnTime;
    private int enemyCount;
    private double enemyRespawnClock;




    // Start is called before the first frame update
    void Start()
    {
        enemyToSpawn = enemyTypePrefab;
        enemyCount = 4;
        enemyRespawnClock = 0;

        for (int i = 0; i < enemyNumber; i++)
        {
            InstantiateEnemy(i);
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (transform.childCount < enemyNumber)
        {
            enemyRespawnClock += Time.deltaTime;

            if (enemyRespawnClock > respawnTime)
            {
                InstantiateEnemy(enemyCount);
                enemyCount++;
                enemyRespawnClock++;
            }

        }
        else
        {
            enemyRespawnClock = 0;
        }
        
    }

    private void InstantiateEnemy(int countName)
    {
        enemyToSpawn = Instantiate(enemyTypePrefab, new Vector3(transform.position.x + Random.Range(0, respawnDistance), transform.position.y + Random.Range(0, respawnDistance), 0), Quaternion.identity);
        enemyToSpawn.name = transform.name + "enemic" + countName;
        enemyToSpawn.transform.SetParent(this.transform);
    }
}
