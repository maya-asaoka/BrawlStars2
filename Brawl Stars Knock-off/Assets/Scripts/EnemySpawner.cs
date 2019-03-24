using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public GameObject player;
    public float radOfSpawn = 0.1f;

    private Vector3[] spawnPts = { };
    private int xzMinMax = 30;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++) {
            spawnPts[i] = new Vector3(Random.Range(-xzMinMax, xzMinMax), 10, Random.Range(-xzMinMax, xzMinMax));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy()
    {
        for (int i = 0; i < spawnPts.Length * 10; i++)
        {
            Vector3 spawnPt = spawnPts[Random.Range(0, spawnPts.Length)];
            if (CheckPlayerLocation(spawnPt)) {
                GameObject enemy = Instantiate(enemyPrefab);
                enemy.transform.position = spawnPt;
            }
        }

    }


    public bool CheckPlayerLocation(Vector3 loc)
    {
        return Vector3.Distance(player.transform.position, loc) > radOfSpawn;
    }
      
}
