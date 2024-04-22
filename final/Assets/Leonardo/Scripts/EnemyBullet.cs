using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float lifeTimeBullet = 5f;
    [SerializeField] float shootTime;
    [SerializeField] float shootForce = 200f;
    [SerializeField] Transform bulletsParent;

    private Vector3 lastPosition;
    [SerializeField] LayerMask hitLayers;

    private void Start()
    {

    }

    void OnEnable()
    {
        lastPosition = transform.position;

        bulletsParent = GameObject.Find("BalasEnemyPadre").GetComponent<Transform>();
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
        Debug.Log("Ray Drawn");
        //Debug.DrawRay(lastPosition, direction * distance, Color.red);

        if (Physics.Raycast(lastPosition, direction, out RaycastHit hit, distance, hitLayers))
        {
            PlayerHealth playerHealth = hit.collider.GetComponent<PlayerHealth>();
            DamageManager.instance.DamagePlayer(playerHealth);
            gameObject.SetActive(false);
        }
    }
}


