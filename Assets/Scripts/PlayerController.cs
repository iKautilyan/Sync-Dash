using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed = 8f;
    public float jumpForce = 6f;
    public LayerMask groundMask;
    public Transform groundCheck;
    public float groundDistance = 0.1f;


    Rigidbody rb;
    bool isGrounded;    
    public string playerId = "PlayerRight"; // identifier


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        // Input (tap/click)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Debug.Log("trying jump");
                rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            }
        }
    }


    void FixedUpdate()
    {
        // constant forward movement on Z axis
        Vector3 vel = rb.velocity;
        vel.z = forwardSpeed;
        rb.velocity = vel;


        // ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
    // Called when collecting an orb or hitting obstacle to send event as well
}
