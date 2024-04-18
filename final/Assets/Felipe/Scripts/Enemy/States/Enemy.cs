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

    [SerializeField]
    private string currentState;

    public EnemyPath path;

    private GameObject player;
    public float sightRange = 20f;
    public float fieldOfView = 85f;
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

        CanSeePlayer();
    }
    public bool CanSeePlayer()
    {
        if (player != null)
        {
            //Is the player close enough to be seen
            if (Vector3.Distance(transform.position, player.transform.position) < sightRange)
            {
                Vector3 targetDirection = player.transform.position - transform.position;
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
                if (angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView)
                {
                    Ray ray = new Ray(transform.position, targetDirection);
                    Debug.DrawRay(ray.origin, ray.direction * sightRange, Color.red);
                }
            }
        }
        return true;
    }
}
