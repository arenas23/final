using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : BaseState
{
    private float searchTimer;
    private float losePlayerTime = 10f;
    private float moveTimer;

    public override void Do()
    {
        if (enemy.CanSeePlayer())
            stateMachine.ChangeState(new AttackState());

        if (enemy.Agent.remainingDistance >= enemy.Agent.stoppingDistance) //cuidado
        {
            searchTimer += Time.deltaTime;
            moveTimer += Time.deltaTime;

            if (moveTimer > Random.Range(3, 5))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 10));
                moveTimer = 0;
            }

            if (searchTimer > losePlayerTime)
            {
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }

    public override void Enter()
    {
        enemy.Agent.SetDestination(enemy.LastKnowPos);

    }

    public override void Exit()
    {

    }
}
