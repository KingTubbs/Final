using UnityEngine;
using Classes;

public class MonsterSummonButton : MonoBehaviour
{
    public GameObject monsterPrefab;

    public void SummonHybrid()
    {
        Monster monsterData = MonsterFactory.CreateHybrid();

        GameObject monsterObj = Instantiate(monsterPrefab, Vector3.zero, Quaternion.identity);

        MonsterBehaviour behaviour = monsterObj.GetComponent<MonsterBehaviour>();
        behaviour.Initialize(monsterData);
    }
}