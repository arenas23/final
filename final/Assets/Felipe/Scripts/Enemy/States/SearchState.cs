using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : BaseState
{
    private float searchTimer;
    private float moveTimer;

    public override void Do()
    {
        if (enemy.CanSeePlayer())
        
            stateMachine.ChangeState(new AtackState1());

        Debug.Log("enemy.Agent.remainingDistance: " + enemy.Agent.remainingDistance);
        Debug.Log("enemy.Agent.stoppingDistance: " + enemy.Agent.stoppingDistance);


        if (enemy.Agent.remainingDistance <= enemy.Agent.stoppingDistance) //cuidado
        {
            searchTimer += Time.deltaTime;
            moveTimer += Time.deltaTime;

            Debug.Log("Entro al if " + searchTimer);

            if (moveTimer > Random.Range(3, 5))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 10));
                moveTimer = 0;
            }


            if (searchTimer > 10)
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
