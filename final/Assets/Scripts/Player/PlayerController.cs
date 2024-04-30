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
    [SerializeField] LayerMask oilMask;
    [SerializeField] LayerMask sandMask;
    [SerializeField] float sphereRadius = 0.3f;
    [SerializeField] bool isGrounded;
    [SerializeField] bool isOil;
    [SerializeField] bool isSand;


    [Header("Audio")]
    [SerializeField] bool functionAudioWalk = false;
    [SerializeField] bool functionAudioRun = false;
    [SerializeField] float rangeSpeed;


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
        MovePlayer();
        Gravity();
        Jump();
        Sprint();
    }

    void MovePlayer()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xInput, 0.0f, yInput).normalized; // Normalizamos el vector de dirección
        Vector3 movePlayer = transform.TransformDirection(moveDirection) * speed;

        characterController.Move(movePlayer * Time.deltaTime);

        //Take speed to audio
        rangeSpeed = (Mathf.Abs(movePlayer.x) + Mathf.Abs(movePlayer.z));

        // Animation
        animator.SetFloat("Speed", Mathf.Abs(movePlayer.x) + Mathf.Abs(movePlayer.z));
        animator.SetBool("Grounded", isGrounded);

        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);
        isOil = Physics.CheckSphere(groundCheck.position, sphereRadius, oilMask);
        isSand = Physics.CheckSphere(groundCheck.position, sphereRadius, sandMask);

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
        GameManager.Instance.LosePlayer();
        Destroy(gameObject);
    }

    public int GetSurfaceType()
    {

        if (isGrounded)
        {
            
            return 4; // Suelo Normal
        }
        else if (isOil)
        {
            return 6; // Oil
        }
        else if (isSand)
        {
            return 8; // Arena
        }

        return 0; 
    }

    void Step1GroundPlayer()
    {
   
        if(isSand)
        {
            AudioManager.Instance.PlaySFX(6);
        }
        else if (isOil)
        {
            AudioManager.Instance.PlaySFX(8);
        }
        else
        {
            AudioManager.Instance.PlaySFX(4);
        }
       
    }
    void Step2GroundPlayer()
    {

        if (isSand)
        {
            AudioManager.Instance.PlaySFX(7);
        } else if (isOil)
        {
            AudioManager.Instance.PlaySFX(9);
        }
        else
        {
            AudioManager.Instance.PlaySFX(5);
        }
    }
   
}