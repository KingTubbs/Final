using UnityEngine;
using Interfaces.Items;
using Classes.Player;

public class Chest : MonoBehaviour
{
    public float HP = 10f;
    public int numDrops = 10;               // number of items to drop
    public string bodyPartItemsPath = "BodypartItem"; // folder in Resources

    public void TakeDamage(float amount)
    {
        HP -= amount;
        if (HP <= 0)
        {
            DropItems(); // optional
            ScoreManager.Instance.AddScore(1);  // increment score
            Destroy(gameObject);
        }
    }

    void DropItems()
    {
        // Load all BodyPartItems from Resources
        BodyPartItem[] allItems = Resources.LoadAll<BodyPartItem>(bodyPartItemsPath);

        if (allItems.Length == 0) return;

        for (int i = 0; i < numDrops; i++)
        {
            // Pick a random item
            BodyPartItem item = allItems[Random.Range(0, allItems.Length)];

            // Spawn collectible in the scene
            Vector2 offset = Random.insideUnitCircle * 0.5f;
            GameObject dropObj = new GameObject("Collectible");
            dropObj.transform.position = (Vector2)transform.position + offset;
            SpriteRenderer sr = dropObj.AddComponent<SpriteRenderer>();
            sr.sprite = item.icon;

            // Add collectible behavior
            var collectible = dropObj.AddComponent<Collectible>();
            collectible.item = item;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        MonsterCombat mc = collision.gameObject.GetComponent<MonsterCombat>();
        if (mc != null)
        {
            TakeDamage(mc.Attack);
        }
    }
}