using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemiesPerWave = 5;
    public float spawnRadius = 5f;

    public Transform playerTransform; // usually at (0,0)

    public void SpawnWave()
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {
            Vector3 spawnPos = playerTransform.position + (Vector3)(Random.insideUnitCircle * spawnRadius);
            GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            enemy.GetComponent<Enemy>().Target = playerTransform;
        }
    }
}