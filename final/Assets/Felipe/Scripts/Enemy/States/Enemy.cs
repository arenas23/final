using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    private Animator animator;
    private Rigidbody rigidbody;
    private CapsuleCollider rootColider;
    public float speed;

    public NavMeshAgent Agent { get => agent; }
    public GameObject Player { get => player; }

    [Header("Weapon Values")]
    public Transform gunBarrel;
    [Range(0.1f, 10f)]
    public float fireRate;



    [SerializeField]
    private string currentState;

    public EnemyPath path;

    public GameObject player;
    [Header("Sight Values")]
    public float sightRange = 20f;
    public float fieldOfView = 85f;
    public float eyeHeight;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        rootColider = GetComponent<CapsuleCollider>();
        stateMachine.Initialize();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Felipe add this lines for animator
        speed = agent.velocity.magnitude;
        animator.SetFloat("speed", speed);

        //CanSeePlayer();
        currentState = stateMachine.activeState.ToString();


    }
    
    public bool CanSeePlayer()
    {
        if (player != null)
        {
            //Is the player close enough to be seen
            if (Vector3.Distance(transform.position, player.transform.position) < sightRange)
            {
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHeight);
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
                if (angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView)
                {
                    Ray ray = new Ray(transform.position + (Vector3.up * eyeHeight), targetDirection);
                    Debug.DrawRay(ray.origin, ray.direction * sightRange, Color.green);
                    RaycastHit hitInfo = new RaycastHit();
                    if (Physics.Raycast(ray, out hitInfo, sightRange))
                    {
                        if (hitInfo.transform.gameObject == player)
                        {
                            Debug.DrawRay(ray.origin, ray.direction * sightRange, Color.red);
                            return true;
                        }
                    }
                    // Debug.DrawRay(ray.origin, ray.direction * sightRange, Color.red);//Revizar
                }
            }
        }
        return false;
    }
}
