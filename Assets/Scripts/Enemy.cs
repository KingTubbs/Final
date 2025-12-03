using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float HP = 10f;
    public float Speed = 1f;
    public float Attack = 1f;
    public float AttackRadius = 0.5f;

    public float PlayerHP = 100f;

    private Rigidbody2D rb;
     // Assign in Inspector
    private Transform playerTransform;


    void Awake()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
            playerTransform = p.transform;

        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
            rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    void Update()
    {
        MonsterCombat targetMonster = FindNearestMonsterOrPlayer();

        if (targetMonster == null)
        {
            // Attack player
            if (playerTransform == null) return;

            Vector2 dir = (playerTransform.position - transform.position).normalized;
            rb.MovePosition(rb.position + dir * Speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, playerTransform.position) <= AttackRadius)
            {
                PlayerHP -= Attack;
                Debug.Log("Player damaged! HP = " + PlayerHP);
            }
        }
        else
        {
            // Attack monster
            Vector2 dir = (targetMonster.transform.position - transform.position).normalized;
            rb.MovePosition(rb.position + dir * Speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, targetMonster.transform.position) <= AttackRadius)
            {
                targetMonster.HP -= Attack;
                if (targetMonster.HP <= 0) Destroy(targetMonster.gameObject);
            }
        }
    }

    MonsterCombat FindNearestMonsterOrPlayer()
    {
        Vector2 pos = transform.position;

        // 1. Get monsters
        MonsterCombat[] monsters = FindObjectsByType<MonsterCombat>(FindObjectsSortMode.None);
        MonsterCombat nearestMonster = null;
        float nearestMonsterDist = Mathf.Infinity;

        foreach (var m in monsters)
        {
            float d = (m.transform.position - (Vector3)pos).sqrMagnitude;
            if (d < nearestMonsterDist)
            {
                nearestMonsterDist = d;
                nearestMonster = m;
            }
        }

        // 2. Get player distance
        float playerDist = Mathf.Infinity;
        if (playerTransform != null)
        {
            playerDist = ((Vector2)playerTransform.position - pos).sqrMagnitude;
        }

        // 3. Compare and pick target
        if (playerDist < nearestMonsterDist)
        {
            return null; // nearest is the player
        }

        return nearestMonster;
    }

    public void TakeDamage(float amount)
    {
        HP -= amount;
        if (HP <= 0)
            Destroy(gameObject);
    }
}