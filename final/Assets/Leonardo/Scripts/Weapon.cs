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

    [SerializeField] Transform bulletsParent;
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
        bulletsParent = GameObject.Find("PadreBalas").GetComponent<Transform>();
        BulletInstantiate();
    }

    void Update()
    {
        ShootAmo();
    }

    void BulletInstantiate()
    {
        bulletList = new List<GameObject>();
        GameObject tempBullet;

        for (int i = 0; i < bulletCartridge; i++)
        {
            tempBullet = Instantiate(bulletPrefab);
            tempBullet.SetActive(false);
            bulletList.Add(tempBullet);
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

            GameObject bulletToShoot = GetBullets();
            if (bulletToShoot != null)
            {
                bulletToShoot.transform.position = bulletsParent.transform.position;
                bulletToShoot.SetActive(true);
            }
            else
            {
                Debug.Log("No ammo");
            }
        }
    }
}
