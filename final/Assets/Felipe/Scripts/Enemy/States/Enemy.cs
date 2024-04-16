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
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        rootColider = GetComponent<CapsuleCollider>();
        stateMachine.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        speed = agent.velocity.magnitude;
        animator.SetFloat("speed", speed);
    }
}
