using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // inherited classes can access these
    [SerializeField] protected float movementSpeed;
    [SerializeField] protected float health;
    [SerializeField] protected GameManager gameManager;

    // inherited classes can call this
    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            gameManager.EnemyDefeated();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.TouchPlayer();
        }
    }
}
