using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class EnemyStateMachine : StateManager<EnemyStateMachine.EEnemyState>
{
    public enum EEnemyState
    {
        Idle,
        Patrol,
        Attack
    }

    [SerializeField] private CapsuleCollider _rootColider;
    [SerializeField] private Rigidbody _rigidbody;

    private void ValidateConstraints()
    {
        Assert.IsNotNull(_rootColider, "Capsule Collider is not assigned");
        Assert.IsNotNull(_rigidbody, "Rigidbody is not assigned");
    }

    void Awake()
    {
        ValidateConstraints();
        CurrentState = States[EEnemyState.Idle];
    }

}
