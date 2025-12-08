using UnityEngine;
using System.Linq;
using Classes.Player;
using System.Collections;
using Classes;
using Interfaces.Bodyparts;
using Interfaces.Items;

public class MonsterCreationUIManager : MonoBehaviour
{
    public GameObject monsterCreationUI;

    public BodyPartSlot[] bodyPartSlots;    // Assign all 5 slots in Inspector
    public GameObject createButton;         // Assign create button

    public static MonsterCreationUIManager Instance { get; private set; }

    public InventoryUIManager inventoryUIManager; // drag from Inspector


    private Player player;

    void Start()
    {
        player = FindAnyObjectByType<Player>();
        monsterCreationUI.SetActive(false);
        createButton.SetActive(false);
    }

   

    void Awake()
    {
        Instance = this;
    }

    public Sprite GetSprite(BodyPartType type)
    {
        // adjust based on how your slots are stored
        return bodyPartSlots
            .First(slot => slot.acceptedSlot == type)
            .slotImage.sprite;
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

    private Monster MakeMonster()
    {
        IHead head = bodyPartSlots
            .First(s => s.acceptedSlot == BodyPartType.Head)
            .storedItem.bodyPart as IHead;

        IArmL leftArm = bodyPartSlots
            .First(s => s.acceptedSlot == BodyPartType.LeftArm)
            .storedItem.bodyPart as IArmL;

        IArmR rightArm = bodyPartSlots
            .First(s => s.acceptedSlot == BodyPartType.RightArm)
            .storedItem.bodyPart as IArmR;

        ITorso torso = bodyPartSlots
            .First(s => s.acceptedSlot == BodyPartType.Torso)
            .storedItem.bodyPart as ITorso;

        ILegL leftLeg = bodyPartSlots
            .First(s => s.acceptedSlot == BodyPartType.LeftLeg)
            .storedItem.bodyPart as ILegL;

        ILegR rightLeg = bodyPartSlots
            .First(s => s.acceptedSlot == BodyPartType.RightLeg)
            .storedItem.bodyPart as ILegR;

        return new Monster
        {
            Head = head,
            LeftArm = leftArm,
            RightArm = rightArm,
            Torso = torso,
            LeftLeg = leftLeg,
            RightLeg = rightLeg
        };
    }

    public void ClearSelectedParts()
    {
        foreach (var slot in bodyPartSlots)
        {
            if (slot.storedItem != null)
            {
                // Remove the item from the player's inventory
                player.inventory.RemoveItem(slot.storedItem);

                // Clear the MonsterCreation slot
                slot.storedItem = null;
                slot.slotImage.sprite = null;
                slot.slotImage.enabled = false; // optional
            }
        }

        createButton.SetActive(false);

        // Refresh the inventory UI to reflect the removed items
        if (inventoryUIManager != null)
            inventoryUIManager.RefreshUI();
    }


}