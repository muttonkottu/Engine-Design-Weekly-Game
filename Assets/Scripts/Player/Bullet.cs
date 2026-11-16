using System;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifeTime = 5f;
    [SerializeField] private Rigidbody rb;

    private IObjectPool<Bullet> bulletPool;
    
    private float releaseTime;
    private bool released = true;

    public void Init(IObjectPool<Bullet> pool)
    {
        bulletPool = pool;
    }
    
    public void Launch(Vector3 position, Quaternion rotation, Vector3 velocity)
    {
        transform.SetPositionAndRotation(position, rotation);
        gameObject.SetActive(true);
        
        released = false;
        releaseTime = Time.time + lifeTime;

        rb.linearVelocity = velocity;
        rb.angularVelocity = Vector3.zero;
    }

    private void Update()
    {
        if (!released && Time.time >= releaseTime)
        {
            ReleaseBullet();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (released) return;
        
        if (other.gameObject.CompareTag("Zombie"))
        {
            other.GetComponent<Zombie>().TakeDamage(1);
            ReleaseBullet();
        }
        if (other.gameObject.CompareTag("BigZombie"))
        {
            other.GetComponent<BigZombie>().TakeDamage(1);
            ReleaseBullet();
        }
    }

    private void ReleaseBullet()
    {
        released = true;
        bulletPool.Release(this);
    }
}
