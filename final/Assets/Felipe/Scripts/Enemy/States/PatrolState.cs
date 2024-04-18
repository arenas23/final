using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    public int wayPointIndex = 0;
    public float waitTimer;
    public override void Enter()
    {

    }

    public override void Do()
    {
        PatrolCycle();

    }

    public override void Exit()
    {

    }

    public void PatrolCycle()
    {
        if (enemy.Agent.remainingDistance < 0.2f)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= 3f)
            {

                if (wayPointIndex < enemy.path.wayPoints.Count - 1)
                {
                    wayPointIndex++;
                }
                else
                {
                    wayPointIndex = 0;
                }
                enemy.Agent.SetDestination(enemy.path.wayPoints[wayPointIndex].position);
                waitTimer = 0f;
            }
        }

    }
}
