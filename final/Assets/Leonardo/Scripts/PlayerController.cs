using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController chControllerPlayer;
    [SerializeField] float speed = 5f;
    [SerializeField] float gravity = -9.8f;

    [SerializeField] Transform groundCheck;
    [SerializeField] float sphereRadius = 0.3f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] bool isGrounded;

    [SerializeField] Animator animator;

    [SerializeField] float jumpForce = 3;

    Vector3 velocity;

    void Start()
    {
        groundCheck = transform.Find("GroundCheck");
        chControllerPlayer = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);
        MovePlayer();
        Gravity();
        Jump();
        Sprint();
    }

    void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 movePlayer = transform.right * x + transform.forward * z;
        chControllerPlayer.Move(movePlayer * speed * Time.deltaTime);

        animator.SetFloat("Speed", Mathf.Abs(movePlayer.x) + Mathf.Abs(movePlayer.z));

        animator.SetBool("Grounded", isGrounded);
    }

    void Gravity()
    {
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
        chControllerPlayer.Move(velocity * Time.deltaTime);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2 * gravity);
        }
    }

    void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10f;
        }
        else
        {
            speed = 5f;
        }
    }

}
