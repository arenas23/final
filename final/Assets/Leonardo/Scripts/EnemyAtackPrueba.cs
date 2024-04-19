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
    


    void Start()
    {
        fatherBullets = GameObject.Find("BalasEnemyPadre").GetComponent<Transform>();
        BulletInstantiate();
    }

    void Update()
    {
       
       
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

    public void ShootAmo()
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