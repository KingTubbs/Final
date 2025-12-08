using UnityEngine;
using UnityEngine.UI;

public class BodyPartSlot : MonoBehaviour
{
    public BodyPartType acceptedSlot;  // e.g. Head, Torso, ArmLeft...
    public Image slotImage;            // assign in Inspector
    public BodyPartItem storedItem;    // internal

    private void Start()
    {
        ClearSlot();
    }

    public void TryAssignItem(BodyPartItem item)
    {
        // If the slot already has something, overwrite or return?
        // For now, we overwrite:
        storedItem = item;

        slotImage.enabled = true;
        slotImage.sprite = item.icon;

        Debug.Log($"Assigned {item.itemName} to {acceptedSlot} slot");
    }

    public bool IsFilled()
    {
        return storedItem != null;
    }

    public void ClearSlot()
    {
        storedItem = null;
        slotImage.sprite = null;
        slotImage.enabled = false;
    }
}