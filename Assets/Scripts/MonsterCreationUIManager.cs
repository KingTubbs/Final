using UnityEngine;
using Classes.Player;

public class MonsterCreationUIManager : MonoBehaviour
{
    public GameObject monsterCreationUI;
    private Player player;

    void Start()
    {
        player = FindAnyObjectByType<Player>();
        monsterCreationUI.SetActive(false);
    }

    // Inventory calls this
    public void ToggleMonsterCreation(bool state)
    {
        monsterCreationUI.SetActive(state);

        if (state)
            RefreshUI();
    }

    // For testing only
    public void ToggleMonsterCreation()
    {
        ToggleMonsterCreation(!monsterCreationUI.activeSelf);
    }

    public void RefreshUI()
    {
        // TODO later
    }
}