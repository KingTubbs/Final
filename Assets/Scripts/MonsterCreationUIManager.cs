using UnityEngine;
using System.Linq;
using Classes.Player;

public class MonsterCreationUIManager : MonoBehaviour
{
    public GameObject monsterCreationUI;

    public BodyPartSlot[] bodyPartSlots;    // Assign all 5 slots in Inspector
    public GameObject createButton;         // Assign create button

    private Player player;

    void Start()
    {
        player = FindAnyObjectByType<Player>();
        monsterCreationUI.SetActive(false);
        createButton.SetActive(false);
    }

    public void OnMonsterCreationToggle()
    {
        ToggleMonsterCreation();
    }

    public void ToggleMonsterCreation()
    {
        bool isActive = !monsterCreationUI.activeSelf;
        monsterCreationUI.SetActive(isActive);

        if (isActive)
            RefreshUI();
    }

    public void RefreshUI()
    {
        // Later, we update stats, animations, preview, etc.
    }

    // --- STEP 2: PLACE INVENTORY ITEM INTO SLOT ---
    public void TryPlaceItem(BodyPartItem item)
    {
        // Find the correct slot based on item.partSlot
        BodyPartSlot targetSlot = bodyPartSlots
            .FirstOrDefault(s => s.acceptedSlot == item.partSlot);

        if (targetSlot == null)
        {
            Debug.LogError("No slot matches this item type!");
            return;
        }

        Debug.Log($"Item {item.itemName} wants slot {item.partSlot}");
        foreach (var s in bodyPartSlots)
        {
            Debug.Log($"Slot {s.acceptedSlot} is in UI");
        }

        targetSlot.TryAssignItem(item);

        CheckAllSlotsFilled();
    }

    private void CheckAllSlotsFilled()
    {
        bool allFilled = bodyPartSlots.All(s => s.IsFilled());
        createButton.SetActive(allFilled);
    }
}