using System;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float movementSpeed;
    [SerializeField] protected float health;
    protected Transform playerTransform;

    public virtual void Init(Transform player)
    {
        playerTransform = player;
        GameManager.Instance.AddTotalEnemy();
    }

    public abstract void Attack();

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameManager.Instance.EnemyDefeated();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.TouchPlayer();
        }
    }
}
