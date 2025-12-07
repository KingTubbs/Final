using UnityEngine;
using Interfaces.Items;
using Classes.Bodyparts;
using Interfaces.Bodyparts;
using Classes.Player;
using System;

[CreateAssetMenu(fileName = "NewBodyPartItem", menuName = "Inventory/BodyPartItem")]
public class BodyPartItem : Item, ICollectible
{
    [Header("UI")]
    public Sprite icon;   // For inventory grid icons

    [Header("Monster Creation Slot")]
    public BodyPartType partSlot;  // <-- NEW: tells the UI which slot this belongs to

    [Header("Bodypart Instantiation")]
    public Type bodyPartType;  // Your existing approach (concrete class type)

    public void OnCollect(Player player)
    {
        player.inventory.AddItem(this);
        Debug.Log($"Collected {itemName}");
    }

    public string GetName() => itemName;
    public Sprite GetIcon() => icon;

    public IBodypart CreateBodyPartInstance()
    {
        return (IBodypart)Activator.CreateInstance(bodyPartType, icon);
    }
}