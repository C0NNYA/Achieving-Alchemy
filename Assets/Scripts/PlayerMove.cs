using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed;
    private Vector3 _moveDirection;
    public InputActionReference move;

   
    private void Update()
    {
        _moveDirection = move.action.ReadValue<Vector3>();
    }

    
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(x:_moveDirection.x * moveSpeed,y:_moveDirection.y * moveSpeed,z:_moveDirection.z * moveSpeed);
    }
}
