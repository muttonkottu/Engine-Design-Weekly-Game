using System;
using UnityEngine;

public class Zombie : Enemy
{
    [SerializeField] private Transform player;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, movementSpeed * Time.deltaTime);
    }
}
