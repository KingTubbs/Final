using UnityEngine;
using Classes.Player;
using TMPro;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    public GameObject inventoryUI;
    public GameObject slotPrefab;
    public Transform slotParent;
    private Player player;

    public MonsterCreationUIManager monsterCreationUIManager;

    void Start()
    {
        player = FindAnyObjectByType<Player>();
        inventoryUI.SetActive(false);
    }

    // Called by Input System event
    public void OnInventoryToggle()
    {
        ToggleInventory();
    }

    public void ToggleInventory()
    {
        bool isActive = !inventoryUI.activeSelf;
        inventoryUI.SetActive(isActive);

        // toggle monster creation at the same time
        monsterCreationUIManager.ToggleMonsterCreation();

        if (isActive)
            RefreshUI();
    }

    public void RefreshUI()
    {
        foreach (Transform child in slotParent)
            Destroy(child.gameObject);

        foreach (var item in player.inventory.items)
        {
            Debug.Log("Creating slot for: " + item);

            GameObject slot = Instantiate(slotPrefab, slotParent);

            // Visuals
            slot.transform.Find("Icon").GetComponent<Image>().sprite = item.icon;
            slot.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = item.itemName;

            // Logic
            InventorySlotUI ui = slot.GetComponent<InventorySlotUI>();

            if (ui == null)
            {
                Debug.LogError("InventorySlotUI missing on prefab root!");
            }
            else
            {
                ui.Initialize((BodyPartItem)item, monsterCreationUIManager);
            }
        }
    }
}