using UnityEngine;
using Interfaces.Items;
using Classes.Bodyparts;
using Interfaces.Bodyparts;
using Classes.Player;
using System;
using Interfaces;

[CreateAssetMenu(fileName = "NewBodyPartItem", menuName = "Inventory/BodyPartItem")]
public class BodyPartItem : Item
{
    [Header("Monster Creation Slot")]
    public BodyPartType partSlot;  // Tells the UI which slot this belongs to

    [Header("Bodypart Instantiation")]
    public Type bodyPartType;       // concrete class type
    public IBodypart bodyPart;      // store real stats here

    public void OnCollect(Player player)
    {
        player.inventory.AddItem(this);
        Debug.Log($"Collected {itemName}");
    }

    public IBodypart CreateBodyPartInstance()
    {
        return (IBodypart)Activator.CreateInstance(bodyPartType, icon);
    }
}