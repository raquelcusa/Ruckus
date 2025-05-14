using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Aqu� van los 4 prefabs distintos
    public Transform[] spawnPoints;   // Los puntos posibles de aparici�n
    public float spawnInterval = 10f; // Tiempo entre cada spawn

    void Start()
    {
        StartCoroutine(SpawnEnemiesLoop());
    }

    IEnumerator SpawnEnemiesLoop()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        int spawnIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(enemyPrefabs[enemyIndex], spawnPoints[spawnIndex].position, Quaternion.identity);
    }
}
