using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float tiempoDeVida = 5f;
    private float tiempoDesdeDisparo;
    public float fuerzaDisparo = 20f; // Ajusta esta fuerza según necesites

    void OnEnable()
    {
        tiempoDesdeDisparo = 0f;
        // Aplicar la fuerza de disparo en la dirección hacia adelante del objeto 'Bala'.
        GetComponent<Rigidbody>().AddForce(transform.forward * fuerzaDisparo, ForceMode.Impulse);
    }

    void Update()
    {
        tiempoDesdeDisparo += Time.deltaTime;

        if (tiempoDesdeDisparo >= tiempoDeVida)
        {
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
}
