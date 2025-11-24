using UnityEngine;

public class MonsterCombat : MonoBehaviour
{
    public float HP = 20f;
    public float Attack = 5f;
    public float Speed = 2f;
    public Transform Target; // assign closest enemy dynamically

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