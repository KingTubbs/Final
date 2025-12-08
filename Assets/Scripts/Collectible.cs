using UnityEngine;
using Interfaces.Items;
using Classes.Player;

public class Collectible : MonoBehaviour
{
    public BodyPartItem item;      // Assign ScriptableObject in Inspector
    public float pickupRange = 2f; // Distance required to collect
    private Player player;

    private void Start()
    {
        // Cache reference to player (much cheaper than finding every frame)
        player = FindAnyObjectByType<Player>();
        Debug.Log("Player found? " + (player != null));
    }

    private void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(player.transform.position, transform.position);
        //Debug.Log("Distance = " + distance);

        if (distance <= pickupRange)
        {
            Collect();
            Debug.Log("collecting");
        }
    }

    private void Collect()
    {
        item.OnCollect(player);   // Add to inventory
        Destroy(gameObject);      // Remove pickup from world
    }
}
