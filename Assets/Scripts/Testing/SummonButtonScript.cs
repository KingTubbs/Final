using UnityEngine;
using Classes;
using Classes.Player;

public class MonsterSummonButton : MonoBehaviour
{
    public GameObject monsterPrefab;

    private Player player;

    void Awake()
    {
        player = FindAnyObjectByType<Player>();
    }

    public void SummonCreatedMonster()
    {
        if (player == null) return;

        // Get the Monster data from your UI
        MonsterCreationUIManager ui = MonsterCreationUIManager.Instance;

        // Create the monster
        Monster monsterData = MonsterFactory.CreateFromUI(ui);

        // Consume/remove the body parts
        ui.ClearSelectedParts(); 

        // Spawn at player's position
        Vector3 spawnPos = player.transform.position;

        GameObject monsterObj = Instantiate(monsterPrefab, spawnPos, Quaternion.identity);

        monsterObj.GetComponent<MonsterBehaviour>().Initialize(monsterData);
    }
}