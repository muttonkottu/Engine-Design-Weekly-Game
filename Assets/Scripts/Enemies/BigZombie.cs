using UnityEngine;

public class BigZombie : Enemy
{
    private bool _canMove = false;
    public override void Attack()
    {
        _canMove = true;
    }
    
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage/2);
    }
    
    private void Update()
    {
        if (!playerTransform || _canMove == false) return;
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, movementSpeed * Time.deltaTime);
    }
}
