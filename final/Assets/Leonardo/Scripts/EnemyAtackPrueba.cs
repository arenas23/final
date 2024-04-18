using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAtackPrueba : MonoBehaviour
{
  

    [SerializeField] Transform fatherBullets;
    public List<GameObject> bulletEnemyList;
    [SerializeField] GameObject bulletEnemyPrefab;
    [SerializeField] int bulletEnemyCartridge = 20;

    [SerializeField] float shootingDistance = 10f;
    [SerializeField] Transform playerTransform;

    private bool isShooting = false;


    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        // fatherBullets = GameObject.Find("BalasEnemyPadre").GetComponent<Transform>();
        BulletInstantiate();
    }

    void Update()
    {

        // float distanceToPlayer = Vector3.Distance(playerTransform.position, fatherBullets.position);

        // if (distanceToPlayer <= shootingDistance && !isShooting)
        // {
        //     InvokeRepeating("ShootAmo", 0.2f, 0.5f);
        //     isShooting = true; // Establece que el disparo ha comenzado
        // }
        // else if (distanceToPlayer > shootingDistance && isShooting)
        // {

        //     CancelInvoke("ShootAmo");
        //     isShooting = false; // Establece que el disparo ha terminado
        // }
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