using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float spinSpeed = 360f;
    
    private Rigidbody rb;
    private Vector2 moveInput;
    private bool isGrounded = true;
    private bool isSpinning = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveInput.x, 0f, moveInput.y);
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        if(isSpinning)
        {
            transform.Rotate(0f,spinSpeed * Time.deltaTime, 0f);
        }
    }
    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && isGrounded)
        {
            rb.linearVelocity = new Vector3(
                rb.linearVelocity.x,
                jumpForce,
                rb.linearVelocity.z
            );
            isGrounded = false;
        }
    }
    public void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    public void Spin(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            isSpinning = !isSpinning;
            //transform.Rotate(0f, spinSpeed, 0f);
        }
    }
}
