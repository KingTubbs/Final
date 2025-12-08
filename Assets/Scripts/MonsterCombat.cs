using UnityEngine;

public class MonsterCombat : MonoBehaviour
{
    public float HP = 20f;
    public float Attack = 5f;
    public float Speed = 2f;

    private Rigidbody2D rb;
    private Transform target; // current target chest

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
            rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    void Update()
    {
        // Always find a valid target if needed
        if (target == null || target.GetComponent<Chest>().HP <= 0)
        {
            target = FindClosestChest();
        }

        // Move toward the target
        if (target != null)
        {
            Vector2 dir = (target.position - transform.position).normalized;
            rb.MovePosition(rb.position + dir * Speed * Time.deltaTime);
        }
    }

    Transform FindClosestChest()
    {
        Chest[] chests = FindObjectsByType<Chest>(FindObjectsSortMode.None);
        Transform closest = null;
        float closestDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;

        foreach (Chest c in chests)
        {
            if (c.HP <= 0) continue; // skip destroyed chests
            float dist = (c.transform.position - currentPos).sqrMagnitude;
            if (dist < closestDist)
            {
                closestDist = dist;
                closest = c.transform;
            }
        }

        return closest;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Chest chest = collision.gameObject.GetComponent<Chest>();
        if (chest != null)
        {
            chest.TakeDamage(Attack);
        }
    }
}