using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    public GameObject chestPrefab;
    public Transform player;
    public float buffer = 2f;        
    public float spawnInterval = 3f;

    private float minDistance;
    private float maxDistance;
    private float timer = 0f;

    void Start()
    {
        float v = Camera.main.orthographicSize;
        float h = v * Camera.main.aspect;
        minDistance = Mathf.Max(v, h) + buffer;
        maxDistance = minDistance * 1.5f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnChest();
            timer = 0f;
        }
    }

    void SpawnChest()
    {
        Vector2 dir = Random.insideUnitCircle.normalized;
        float dist = Random.Range(minDistance, maxDistance);
        Vector2 pos = (Vector2)player.position + dir * dist;

        Instantiate(chestPrefab, pos, Quaternion.identity);
    }
}