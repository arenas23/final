using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 9:46
public class AtackState1 : BaseState
{
    private float moveTimer;
    private float losePlayerTimer;
    private float shotTimer;



    public override void Do()
    {
        if (enemy.CanSeePlayer())
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            shotTimer += Time.deltaTime;
            enemy.transform.LookAt(enemy.Player.transform);

            if (shotTimer > enemy.fireRate)
            {
                Shoot();
            }

            if (moveTimer > Random.Range(3, 7))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
        }
        else
        {
            losePlayerTimer += Time.deltaTime;
            if (losePlayerTimer > 8)
            {
                //Change to the search state
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }

    public void Shoot()
    {
        Transform gunbarrel = enemy.gunBarrel;
        //METER LOGICA DE DISPARO
        // Instanciar bala
        //GameObject bullet = GameObject.Instantiate(Resources.Load("Fernanda/Prefabs/Bullet.prefab") as GameObject, gunbarrel.position, enemy.transform.rotation);

        Vector3 shootDirection = (enemy.Player.transform.position - gunbarrel.transform.position).normalized;

        // Instanciar bala
        //bullet.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(Random.Range(-3f, 3f), Vector3.up) * shootDirection * 40;

        Debug.Log("Shoot");
        shotTimer = 0;
    }


    public override void Enter()
    {

    }

    public override void Exit()
    {

    }
}
