using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public float damage = 10f; 

    public void DamageEnemy (EnemyHealth enemyHealth)
    {
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }
    }
}