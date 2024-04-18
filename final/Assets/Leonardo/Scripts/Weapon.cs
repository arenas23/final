using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{
    public static Weapon instance
    {
        get;
        private set;
    }

    [SerializeField] Transform fatherBullets;
    [SerializeField] List<GameObject> bulletList;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] int bulletCartridge = 30;

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

    void Start()
    {
        fatherBullets = GameObject.Find("PadreBalas").GetComponent<Transform>();
        BulletInstantiate();
    }

    void Update()
    {
        ShootAmo();
    }

    void BulletInstantiate()
    {
        bulletList = new List<GameObject>();
        GameObject balaTemporal;

        for (int i = 0; i < bulletCartridge; i++)
        {
            balaTemporal = Instantiate(bulletPrefab);
            balaTemporal.SetActive(false);
            bulletList.Add(balaTemporal);
        }
    }

    GameObject GetBullets()
    {
        for (int i = 0; i < bulletCartridge; i++)
        {
            if (!bulletList[i].activeInHierarchy)
            {
                return bulletList[i];
            } 
        }  
        return null;
    }

    void ShootAmo()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
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

}
