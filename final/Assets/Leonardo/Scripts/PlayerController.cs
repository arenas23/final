using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController chControllerPlayer;
    public float speed = 10f;
    public float gravity = -9.8f;

    public Transform groundCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groundMask;
    bool isGrounded;

    Vector3 velocity;

    void Start()
    {
        groundCheck = transform.Find("GroundCheck");
        chControllerPlayer = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);

        if( isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movePlayer = transform.right * x + transform.forward * z;

        chControllerPlayer.Move(movePlayer * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        chControllerPlayer.Move(velocity * Time.deltaTime);
    }
}
