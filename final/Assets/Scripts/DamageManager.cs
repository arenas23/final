using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public static DamageManager instance
    {
        get;
        private set;
    }
    public float damage = 10f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void DamageEnemy(EnemyHealth enemyHealth)
    {
        Debug.Log(enemyHealth);
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }
    }

    public void DamagePlayer(PlayerHealth playerHealth)
    {
        Debug.Log(playerHealth);
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}