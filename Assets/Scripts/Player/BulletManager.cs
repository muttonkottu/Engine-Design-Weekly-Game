using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActionAsset;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;

    private InputAction _shootAction;

    private void Awake()
    {
        _shootAction = inputActionAsset.FindActionMap("Player").FindAction("Shoot");
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
        GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
    
        if (newBullet.TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb.linearVelocity = transform.forward * bulletSpeed;
        }
    }
}
