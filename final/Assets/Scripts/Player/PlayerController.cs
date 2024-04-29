using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    Animator animator;
    [SerializeField] float health = 100f;

    [Header("Movement")]
    float speed = 20f;
    float walkSpeed = 20f;
    float runSpeed = 30f;
    [SerializeField] float jumpForce = 3;
    [SerializeField] float gravity = -9.8f;
    private Vector3 velocity;

    [Header("Ground Check")]
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float sphereRadius = 0.3f;
    [SerializeField] bool isGrounded;
    public float Health
    {
        get { return health; }
    }

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

    public void Heal(float heal)
    {
        health += heal;
        if (health > 100f)
        {
            health = 100f;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player died");
        GameManager.Instance.LosePlayer();
        Destroy(gameObject);
    }

}
