using System;
using UnityEngine;

public class Zombie : Enemy
{
    private bool _canMove = false;
    public override void Attack()
    {
        _canMove = true;
    }
    
    private void Update()
    {
        if (!playerTransform || _canMove == false) return;
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, movementSpeed * Time.deltaTime);
    }
}
