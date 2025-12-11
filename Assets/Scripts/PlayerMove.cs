using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed;
    private Vector3 _moveDirection;
    public InputActionReference move;
    public InputActionReference jump;
    public float jumpForce;
    public InputActionReference look;
    public float lookSensitivity = 2f;
    public Transform cameraTransform;
    private float _xRotation = 0f;



    private void Update()
    {
        _moveDirection = move.action.ReadValue<Vector3>();
    }

    private void LateUpdate()
    {
        Vector2 lookInput = look.action.ReadValue<Vector2>();
        float mouseX = lookInput.x * lookSensitivity;
        float mouseY = lookInput.y * lookSensitivity;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);
    }



    private void FixedUpdate()
    {
        Vector3 currentY = new Vector3(0, rb.linearVelocity.y, 0);

        Vector3 moveDir = transform.TransformDirection(new Vector3(_moveDirection.x, 0, _moveDirection.z));
        Vector3 horizontalVelocity = moveDir * moveSpeed;


        rb.linearVelocity = horizontalVelocity + currentY;
    }


    private void OnEnable()
    {
        jump.action.started += Jump;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    private void OnDisable()
    {
        jump.action.started -= Jump;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    private void Jump(InputAction.CallbackContext context)
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
