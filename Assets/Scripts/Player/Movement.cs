using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private CharacterController controller;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    private Vector2 _movementInput;

    private void Update()
    {
        Vector3 cameraForward = Vector3.ProjectOnPlane(cameraTransform.forward, Vector3.up).normalized;
        Vector3 cameraRight = Vector3.ProjectOnPlane(cameraTransform.right, Vector3.up).normalized;
        Vector3 moveDirection = (cameraForward * _movementInput.y + cameraRight * _movementInput.x).normalized;

        if (_movementInput.sqrMagnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
        
        controller.Move(moveDirection * (movementSpeed * Time.deltaTime));
    }

    public void OnMove(InputValue value)
    {
        _movementInput = value.Get<Vector2>();
    }
}
