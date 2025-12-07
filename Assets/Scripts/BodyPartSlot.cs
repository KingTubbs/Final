using UnityEngine;
using UnityEngine.UI;

public class BodyPartSlot : MonoBehaviour
{
    [Header("Slot Type")]
    public BodyPartType acceptedSlot; // e.g., Head, LeftArm, Torso, etc.

    [Header("UI")]
    public Image iconImage;          // The visual image in the UI slot

    // The item currently assigned to this slot
    [HideInInspector] 
    public BodyPartItem assignedItem;

    // Called by MonsterCreationUIManager when applying an item
    public bool TryAssignItem(BodyPartItem item)
    {
        // Check type match
        if (item.partSlot != acceptedSlot)
        {
            Debug.Log("Item does not belong in this slot.");
            return false;
        }

        assignedItem = item;
        iconImage.sprite = item.icon;
        iconImage.enabled = true;

        return true;
    }

    // For replacing or clearing the slot
    public void ClearSlot()
    {
        assignedItem = null;
        iconImage.sprite = null;
        iconImage.enabled = false;
    }

    public bool IsFilled() => assignedItem != null;
}