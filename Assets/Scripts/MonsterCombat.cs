using UnityEngine;

public class MonsterCombat : MonoBehaviour
{
    public float HP = 20f;
    public float Attack = 5f;
    public float Speed = 2f;
    private float targetRefreshTimer = 0f;
    public Transform Target; // assign closest enemy dynamically

    private Rigidbody2D rb;
    
    Transform FindClosestEnemy()
    {
        Enemy[] enemies = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        Transform closest = null;
        float closestDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;

        foreach (Enemy e in enemies)
        {
            float dist = (e.transform.position - currentPos).sqrMagnitude;
            if (dist < closestDist && e.HP > 0) // makes sure we don't target dead enemies
            {
                closestDist = dist;
                closest = e.transform;
            }
        }

        return closest;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
            rb = gameObject.AddComponent<Rigidbody2D>();

        rb.gravityScale = 0;

    }

    void Update()
    {
        targetRefreshTimer -= Time.deltaTime;
        if (targetRefreshTimer <= 0f)
        {
            Target = FindClosestEnemy();
            targetRefreshTimer = 0.2f; // refresh 5 times per second
        }

        if (Target != null)
        {
            Vector2 dir = (Target.position - transform.position).normalized;
            rb.MovePosition(rb.position + dir * Speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(Attack);
            HP -= 1f; // simple enemy attack
        }
    }
}