using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystemScript : MonoBehaviour
{
    public List<EnemyScript> enemiesPrefabList = new List<EnemyScript>();

    private int enemyCount= 1;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform enemySpawnParent;


    [SerializeField] private int enemiesPerWave = 5;
    [SerializeField] private float timeBetweenEnemies = 2f;
    [SerializeField] private float timeBetweenWaves = 10f;

    private int currentWave = 0;
    private float enemyspeed = 1f;

   

    public IEnumerator SpawnWaves()
    {
        while (true && !GameManager.IsEnemyReached)
        {
            currentWave++;

            Debug.Log("Wave " + currentWave);

            for (int i = 0; i < enemiesPerWave; i++)
            {
                SpawnEnemy(enemyspeed);
                yield return new WaitForSeconds(timeBetweenEnemies);
            }

            enemiesPerWave += 2; // Difficulty increase
            enemyspeed += 0.1f;
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }
    public static List<EnemyScript> EnemySpawnedList = new List<EnemyScript>();
    private void SpawnEnemy(float speed)
    {
        for(int i = 0; i < enemyCount; i++)
        {
            EnemyScript enemyClone = Instantiate(enemiesPrefabList[i], spawnPoint.position, Quaternion.identity);
            enemyClone.transform.SetParent(enemySpawnParent, true);
            enemyClone.moveSpeed = speed;
            EnemySpawnedList.Add(enemyClone);
        }

    }
}
