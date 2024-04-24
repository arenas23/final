using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float damage = 10f;
    [SerializeField] float lifeTimeBullet = 5f;
    [SerializeField] float shootTime;
    [SerializeField] float shootForce = 200f;
    [SerializeField] Transform bulletsParent;

    [SerializeField] LayerMask hitLayers;
    private Vector3 lastPosition;

    private void Start()
    {

    }
    void OnEnable()
    {
        lastPosition = transform.position;

        bulletsParent = GameObject.Find("PadreBalas").GetComponent<Transform>();
        shootTime = 0f;

        GetComponent<Rigidbody>().AddForce(bulletsParent.forward * shootForce, ForceMode.Impulse);
    }

    void Update()
    {
        BulletDestroy();
        RaycastCheck();
        lastPosition = transform.position;
    }

    private void OnDisable()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    void BulletDestroy()
    {
        shootTime += Time.deltaTime;

        if (shootTime >= lifeTimeBullet)
        {
            gameObject.SetActive(false);
        }
    }

    void RaycastCheck()
    {
        Vector3 direction = transform.position - lastPosition;
        float distance = direction.magnitude;

        if (Physics.Raycast(lastPosition, direction, out RaycastHit hit, distance, hitLayers))
        {
            if (hit.collider.GetComponent<Enemy>() != null)
            {
                Debug.Log("Hit enemy");
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                enemy.TakeDamage(damage);
                gameObject.SetActive(false);
            }
        }
    }
}

