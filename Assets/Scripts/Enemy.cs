using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float HP = 10f;
    public float Speed = 1f;
    public float Attack = 1f;
    public float AttackRadius = 0.5f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
            rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    void Update()
    {
        MonsterCombat nearestMonster = FindNearestMonster();
        if (nearestMonster != null)
        {
            Vector2 dir = (nearestMonster.transform.position - transform.position).normalized;
            rb.MovePosition(rb.position + dir * Speed * Time.deltaTime);

            // Attack if in range
            if (Vector2.Distance(transform.position, nearestMonster.transform.position) <= AttackRadius)
            {
                nearestMonster.HP -= Attack;
                if (nearestMonster.HP <= 0) Destroy(nearestMonster.gameObject);
            }
        }
    }

    MonsterCombat FindNearestMonster()
    {
        MonsterCombat[] monsters = FindObjectsOfType<MonsterCombat>();
        MonsterCombat nearest = null;
        float minDist = Mathf.Infinity;

        foreach (var m in monsters)
        {
            float dist = Vector2.Distance(transform.position, m.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                nearest = m;
            }
        }

        return nearest;
    }

    public void TakeDamage(float amount)
    {
        HP -= amount;
        if (HP <= 0)
            Destroy(gameObject);
    }
}