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

    public float jumpForce = 3;

    Vector3 velocity;

    void Start()
    {
        groundCheck = transform.Find("GroundCheck");
        chControllerPlayer = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);
        MovePlayer();
        Gravity();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2 * gravity);
        }
    }

    public void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movePlayer = transform.right * x + transform.forward * z;
        chControllerPlayer.Move(movePlayer * speed * Time.deltaTime);
    }

    public void Gravity()
    {
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        chControllerPlayer.Move(velocity * Time.deltaTime);
    }

    public void Jump()
    {

    }


}
