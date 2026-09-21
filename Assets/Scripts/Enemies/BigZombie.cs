using UnityEngine;

public class BigZombie : Enemy
{
    [SerializeField] private Transform player;

    public override void TakeDamage(float damage)
    {
        health -= (damage / 2);
        if (health <= 0)
        {
            gameManager.EnemyDefeated();
            Destroy(gameObject);
        }
    }
    
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, movementSpeed * Time.deltaTime);
    }
}
