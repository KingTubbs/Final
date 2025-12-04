using UnityEngine;
using Interfaces.Items;
using Classes.Bodyparts;
using Interfaces.Bodyparts;
using Classes.Player;
using System;

[CreateAssetMenu(fileName = "NewBodyPartItem", menuName = "Inventory/BodyPartItem")]
public class BodyPartItem : Item, ICollectible
{
    public Sprite icon; // for inventory UI
    public Type bodyPartType; // stores the concrete class type

    public void OnCollect(Player player)
    {
        player.inventory.AddItem(this);
        Debug.Log($"Collected {itemName}");
    }

    public string GetName() => itemName;
    public Sprite GetIcon() => icon;

    // This will instantiate the concrete BodyPart stats when needed
    public IBodypart CreateBodyPartInstance()
    {
        // Assumes the concrete class has a constructor that takes a Sprite
        return (IBodypart)Activator.CreateInstance(bodyPartType, icon);
    }
}