using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour
{

    [SerializeField] Transform bulletsParent;
    [SerializeField] List<GameObject> bulletList;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] int bulletCartridge = 30;
    [SerializeField] HealthBar healthBar;
    [SerializeField] private Canvas canvas;
    float heat = 0f;
    float maxHeat = 100f;
    [SerializeField] float heatPerBullet = 10f;
    [SerializeField] float coolRate = 10f;
    bool canShoot = true;
    bool bulletFired = false;
    float fireRate = 0.2f;
    float fireTimer = 0f;

    void Start()
    {
        bulletsParent = GameObject.Find("PadreBalas").GetComponent<Transform>();
        BulletInstantiate();
    }

    void Update()
    {

        if (bulletFired)
        {
            fireTimer += Time.deltaTime;
            if (fireTimer >= fireRate)
            {
                fireTimer = 0f;
                bulletFired = false;
            }
        }

        if (Input.GetKey(KeyCode.Mouse0) && canShoot && !bulletFired)
        {
            if (!GameManager.Instance.IsPaused)
            {
                ShootAmo();
                bulletFired = true;
            }
             
        }

        if (heat > 0)
        {
            heat -= coolRate * Time.deltaTime;
            healthBar.SetProgress(heat / maxHeat);
        }

        if (heat < 0)
        {
            heat = 0;
            if (!canShoot) coolRate -= 10f;
            canShoot = true;

        }


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
        GameObject bulletToShoot = GetBullets();
        if (bulletToShoot != null)
        {
            heat += heatPerBullet;
            healthBar.SetProgress(heat / maxHeat);

            if (heat >= maxHeat)
            {
                canShoot = false;
                coolRate += 10f;
            }


            bulletToShoot.transform.position = bulletsParent.transform.position;
            bulletToShoot.SetActive(true);
            AudioManager.Instance.PlaySFX(0);
        }
        else
        {
            Debug.Log("No ammo");
        }
    }
}
