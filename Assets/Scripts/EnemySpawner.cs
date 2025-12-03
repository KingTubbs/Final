using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public float buffer = 2f;        // how far off-screen to spawn
    public float spawnInterval = 2f;

    private float minDistance;
    private float maxDistance; // you can tune this

    

    void Start()
    {
        float v = Camera.main.orthographicSize;
        float h = v * Camera.main.aspect;
        minDistance = Mathf.Max(v, h) + buffer;
        maxDistance = minDistance * 1.5f;
    }

    void Update()
    {
        if (Time.time >= spawnInterval)
        {
            SpawnEnemy();
            spawnInterval += spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        Vector2 dir = UnityEngine.Random.insideUnitCircle.normalized;
        float dist = UnityEngine.Random.Range(minDistance, maxDistance);
        Vector2 pos = (Vector2)player.position + dir * dist;

        Instantiate(enemyPrefab, pos, Quaternion.identity);
    }
}