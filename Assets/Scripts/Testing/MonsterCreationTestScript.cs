using UnityEngine;
using Classes;
using Interfaces.Abilities;

public class MonsterCreationTestScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Monster m = MonsterFactory.CreateRandomHybrid();

        Debug.Log($"HP: {m.TotalHP}");
        Debug.Log($"Attack: {m.TotalAttack}");
        Debug.Log($"Speed: {m.TotalSpeed}");

        Debug.Log("Abilities:");
        foreach (var a in m.ActiveAbilities)
            Debug.Log(a.Name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
