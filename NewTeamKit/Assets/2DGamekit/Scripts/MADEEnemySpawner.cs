using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;


public class MADEEnemySpawner : MonoBehaviour {

    public GameObject enemyPrefab;

    float spawnDistance = 5.0f;

    float enemyRate = 0.2f;
    float nextEnemy = 1;
    	
	// Update is called once per frame
	void Update () {
        nextEnemy -= Time.deltaTime;
        
        if(nextEnemy <= 0)
        {
            nextEnemy = enemyRate;
            enemyRate *= 0.9f;
            if (enemyRate < 2)
                enemyRate = 2;

            Vector3 offset = Random.insideUnitSphere;

            offset.z = 0;

            offset = offset.normalized * spawnDistance;

            Instantiate(enemyPrefab, transform.position + offset, Quaternion.identity);
        }	
	}
}
