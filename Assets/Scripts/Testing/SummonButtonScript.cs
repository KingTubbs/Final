using UnityEngine;
using Classes;

public class MonsterSummonButton : MonoBehaviour
{
    public GameObject monsterPrefab;
    public float spawnRadius = 5f; // distance around the player to spawn monsters

    public void SummonRandomHybrid()
    {
        Monster monsterData = MonsterFactory.CreateRandomHybrid();

        // Random position around (0,0) within a circle of radius spawnRadius
        Vector2 randomOffset = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPos = new Vector3(randomOffset.x, randomOffset.y, 0f);

        GameObject monsterObj = Instantiate(monsterPrefab, spawnPos, Quaternion.identity);

        MonsterBehaviour behaviour = monsterObj.GetComponent<MonsterBehaviour>();
        behaviour.Initialize(monsterData);
    }
}