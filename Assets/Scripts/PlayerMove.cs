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


    private void Update()
    {
        _moveDirection = move.action.ReadValue<Vector3>();
    }


    private void FixedUpdate()
    {
        Vector3 currentY = new Vector3(0, rb.linearVelocity.y, 0);

        Vector3 horizontalVelocity = new Vector3(
            _moveDirection.x * moveSpeed,
            0,
            _moveDirection.z * moveSpeed
        );

        rb.linearVelocity = horizontalVelocity + currentY;
    }


    private void OnEnable()
    {
        jump.action.started += Jump; 
    }

    private void OnDisable()
    {
        jump.action.started -= Jump;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
