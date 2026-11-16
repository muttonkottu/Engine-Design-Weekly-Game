using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Pool;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActionAsset;
    [SerializeField] private Bullet bullet;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int defaultBulletCapacity = 10;
    [SerializeField] private int maxBullets = 50;
    private ObjectPool<Bullet> bulletPool;

    private InputAction _shootAction;

    private void Awake()
    {
        _shootAction = inputActionAsset.FindActionMap("Player").FindAction("Shoot");

        bulletPool = new ObjectPool<Bullet>(
            createFunc: CreateBullet,
            actionOnGet: null,
            actionOnRelease: b => b.gameObject.SetActive(false),
            actionOnDestroy: b => Destroy(b.gameObject),
            collectionCheck: false,
            defaultCapacity: defaultBulletCapacity,
            maxSize: maxBullets
            );
    }

    private Bullet CreateBullet()
    {
        Bullet newBullet = Instantiate(bullet);
        newBullet.gameObject.SetActive(false);
        newBullet.Init(bulletPool);
        return newBullet;
    }

    private void OnEnable()
    {
        _shootAction.performed += OnShootPressed;
        _shootAction.Enable();
    }

    private void OnShootPressed(InputAction.CallbackContext context)
    {
        Shoot();
    }

    private void Shoot()
    {
        Bullet newBullet = bulletPool.Get();
        newBullet.Launch(transform.position, transform.rotation, transform.forward * bulletSpeed);
    }
}
