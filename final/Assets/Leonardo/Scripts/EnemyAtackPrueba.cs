using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAtackPrueba : MonoBehaviour
{
  

    [SerializeField] Transform fatherBullets;
    [SerializeField] List<GameObject> bulletEnemyList;
    [SerializeField] GameObject bulletEnemyPrefab;
    [SerializeField] int bulletEnemyCartridge = 20;

    [SerializeField] float shootingDistance = 10f; // Establece la distancia a la que se puede disparar
    [SerializeField] Transform playerTransform; // Referencia al transform del jugador

    private bool isShooting = false;


    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        fatherBullets = GameObject.Find("BalasEnemyPadre").GetComponent<Transform>();
        BulletInstantiate();
    }

    void Update()
    {
       //ShootAmo();

        // Calcula la distancia entre el jugador y el objeto fatherBullets
        float distanceToPlayer = Vector3.Distance(playerTransform.position, fatherBullets.position);

        // Verifica si la distancia es menor o igual a la distancia de disparo establecida
        if (distanceToPlayer <= shootingDistance && !isShooting)
        {
            // Comienza a disparar si el jugador está a la distancia adecuada y no se ha iniciado el disparo
            InvokeRepeating("ShootAmo", 0.2f, 0.5f);
            isShooting = true; // Establece que el disparo ha comenzado
        }
        else if (distanceToPlayer > shootingDistance && isShooting)
        {
            // Detiene el disparo si el jugador está fuera de la distancia de disparo
            CancelInvoke("ShootAmo");
            isShooting = false; // Establece que el disparo ha terminado
        }
    }

    void BulletInstantiate()
    {
        bulletEnemyList = new List<GameObject>();
        GameObject balaTemporal;

        for (int i = 0; i < bulletEnemyCartridge; i++)
        {
            balaTemporal = Instantiate(bulletEnemyPrefab);
            balaTemporal.SetActive(false);
            bulletEnemyList.Add(balaTemporal);
        }
    }

    GameObject GetBullets()
    {
        for (int i = 0; i < bulletEnemyCartridge; i++)
        {
            if (!bulletEnemyList[i].activeInHierarchy)
            {
                return bulletEnemyList[i];
            }
        }
        return null;
    }

    void ShootAmo()
    {
        GameObject balaTemporal = GetBullets();
        if (balaTemporal != null)
        {
            balaTemporal.transform.position = fatherBullets.transform.position;
            balaTemporal.SetActive(true);
        }
        else
        {
            Debug.Log("Sin balas");
        }

    }

}