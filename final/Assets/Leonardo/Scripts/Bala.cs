using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float tiempoDeVida = 5f;
    private float tiempoDesdeDisparo;
    public float fuerzaDisparo = 50f; // Ajusta esta fuerza según necesites
    public Transform balaPadre;

    private void Start()
    {
        
    }
    void OnEnable()
    {
        balaPadre = GameObject.Find("PadreBalas").GetComponent<Transform>();
        tiempoDesdeDisparo = 0f;
        
        GetComponent<Rigidbody>().AddForce(balaPadre.forward * fuerzaDisparo, ForceMode.Impulse);
        
    }

    void Update()
    {
      
        tiempoDesdeDisparo += Time.deltaTime;

        if (tiempoDesdeDisparo >= tiempoDeVida)
        {
            gameObject.SetActive(false); 
        }
    }

    private void OnDisable()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    void OnCollisionEnter(Collision collision)
    {
       gameObject.SetActive(false);
      
    }
}
