using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    Animator animator;

    [Header("Movement")]
    [SerializeField] float speed = 5f;
    [SerializeField] float walkSpeed = 5f;
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpForce = 3;
    [SerializeField] float gravity = -9.8f;
    private Vector3 velocity;

    [Header("Ground Check")]
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float sphereRadius = 0.3f;
    [SerializeField] bool isGrounded;


    void Start()
    {
        groundCheck = transform.Find("GroundCheck");
        characterController = GetComponent<CharacterController>();
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
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        Vector3 movePlayer = transform.right * xInput + transform.forward * yInput;
        characterController.Move(movePlayer * speed * Time.deltaTime);

        // Animation
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
        characterController.Move(velocity * Time.deltaTime);
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
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
    }
}
