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


    private void Update()
    {
        _moveDirection = move.action.ReadValue<Vector3>();
    }

    
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(x:_moveDirection.x * moveSpeed,y:_moveDirection.y * moveSpeed,z:_moveDirection.z * moveSpeed);
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
        Debug.Log("Jumped!");
    }
}
