using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Zombie"))
        {
            other.GetComponent<Zombie>().TakeDamage(1);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("BigZombie"))
        {
            other.GetComponent<BigZombie>().TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
