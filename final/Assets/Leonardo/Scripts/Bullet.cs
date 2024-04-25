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

    [SerializeField] GameObject electricalParticle;

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
                GameObject newParticle = Instantiate(electricalParticle, transform);
                newParticle.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
                newParticle.transform.rotation = new Quaternion(0, transform.rotation.y - 180f,0 ,0);
                Enemy enemy = hit.collider.GetComponent<Enemy>();
                enemy.TakeDamage(damage);
                gameObject.SetActive(false);
                
            }
        }
    }
}

