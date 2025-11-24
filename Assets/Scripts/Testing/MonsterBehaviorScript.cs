using UnityEngine;
using Classes;
using Interfaces.Abilities;

public class MonsterBehaviour : MonoBehaviour
{
    public Monster Data { get; private set; }

    void SetSprite(string partName, Sprite sprite)
    {
        Transform t = transform.Find(partName);
        if (t == null)
        {
            Debug.LogWarning($"Prefab missing child: {partName}");
            return;
        }

        SpriteRenderer sr = t.GetComponent<SpriteRenderer>();
        if (sr == null)
        {
            Debug.LogWarning($"{partName} missing SpriteRenderer component");
            return;
        }

        if (sprite == null)
        {
            Debug.LogWarning($"{partName} has null Sprite");
            return;
        }

        sr.sprite = sprite;
        Debug.Log($"{partName} sprite applied successfully!");
    }

    public void Initialize(Monster data)
    {
        Data = data;

        Debug.Log("Monster summoned:");
        Debug.Log($"{Data.TotalHP} HP, {Data.TotalAttack} ATK, {Data.TotalSpeed} SPD");

        foreach (var a in Data.ActiveAbilities)
            Debug.Log($"Active: {a.Name}");
        foreach (var p in Data.PassiveAbilities)
            Debug.Log($"Passive: {p.Name}");

        // Check for null body parts
        if (Data.Head == null) Debug.LogError("Monster Head is null!");
        if (Data.LeftArm == null) Debug.LogError("Monster LeftArm is null!");
        if (Data.RightArm == null) Debug.LogError("Monster RightArm is null!");
        if (Data.Torso == null) Debug.LogError("Monster Torso is null!");
        if (Data.LeftLeg == null) Debug.LogError("Monster LeftLeg is null!");
        if (Data.RightLeg == null) Debug.LogError("Monster RightLeg is null!");

        // Apply sprites
        SetSprite("Head", Data.Head?.Sprite);
        SetSprite("LeftArm", Data.LeftArm?.Sprite);
        SetSprite("RightArm", Data.RightArm?.Sprite);
        SetSprite("Torso", Data.Torso?.Sprite);
        SetSprite("LeftLeg", Data.LeftLeg?.Sprite);
        SetSprite("RightLeg", Data.RightLeg?.Sprite);

        // Debug: list all child names in prefab
        Debug.Log("Prefab children:");
        foreach (Transform child in transform)
        {
            Debug.Log($" - {child.name}");
        }
    }
}