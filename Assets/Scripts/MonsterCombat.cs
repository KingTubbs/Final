using UnityEngine;
public class MonsterCombat : MonoBehaviour
{
    public float HP = 20f;
    public float Attack = 5f;

    // Must be public!
    public void TakeDamage(float amount)
    {
        HP -= amount;
        if (HP <= 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(Attack);
        }
    }
}