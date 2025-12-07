using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public Image iconImage;

    private BodyPartItem storedItem;
    private MonsterCreationUIManager creationUI;

    public void Initialize(BodyPartItem item, MonsterCreationUIManager ui)
    {
        storedItem = item;
        creationUI = ui;

        iconImage.sprite = item.icon;
        iconImage.enabled = true;
    }

    // Called when player clicks the slot
    public void OnClick()
    {
        if (storedItem != null)
        {
            creationUI.TryPlaceItem(storedItem);
        }
    }
}