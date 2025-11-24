using UnityEngine;
using Classes;
using Interfaces.Abilities;


public class MonsterBehaviour : MonoBehaviour
{
    public Monster Data { get; private set; }

    public void Initialize(Monster data)
    {
        Data = data;

        Debug.Log("Monster summoned:");
        Debug.Log($"{Data.TotalHP} HP, {Data.TotalAttack} ATK, {Data.TotalSpeed} SPD");
        
        foreach (var a in Data.ActiveAbilities)
            Debug.Log($"Active: {a.Name}");

        foreach (var p in Data.PassiveAbilities)
            Debug.Log($"Passive: {p.Name}");
    }
}