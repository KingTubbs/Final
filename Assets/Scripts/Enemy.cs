using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float HP = 10f;
    public float Speed = 1f;
    public float Damage = 1f;
    public float AttackRange = 0.5f;
    public float AttackCooldown = 1f;

    public Transform Target; // Where enemy moves toward
    private float attackTimer = 0f;

    void Update()
    {
        // Move toward target
        if (Target != null)
        {
            Vector3 dir = (Target.position - transform.position).normalized;
            transform.position += dir * Speed * Time.deltaTime;
        }

        // Handle attacking nearby monsters
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0f)
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, AttackRange);
            foreach (var hit in hits)
            {
                MonsterCombat mc = hit.GetComponent<MonsterCombat>();
                if (mc != null)
                {
                    mc.TakeDamage(Damage);
                    attackTimer = AttackCooldown; // reset cooldown after hitting one monster
                    break; // only hit one per cooldown
                }
            }
        }
    }

    public void TakeDamage(float amount)
    {
        HP -= amount;
        if (HP <= 0f)
            Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }
}