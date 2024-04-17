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

    public Transform padreBalas;
    public List<GameObject> balasList;
    public GameObject balaPrefab;
    public int cartucho = 30;

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
        padreBalas = GameObject.Find("PadreBalas").GetComponent<Transform>();
        InstanciaBalas();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject balaTemporal = ObtenerBalas();
            if(balaTemporal != null)
            {
                balaTemporal.transform.position = padreBalas.transform.position;
                balaTemporal.SetActive(true);
            }
            else
            {
                Debug.Log("Sin balas");
            }
            
  
        }
    }

    public void InstanciaBalas()
    {
        balasList = new List<GameObject>();
        GameObject balaTemporal;

        for (int i = 0; i < cartucho; i++)
        {
            balaTemporal = Instantiate(balaPrefab);
            balaTemporal.SetActive(false);
            balasList.Add(balaTemporal);
        }
    }

    public GameObject ObtenerBalas()
    {
        for (int i = 0; i < cartucho; i++)
        {
            if (!balasList[i].activeInHierarchy)
            {

                return balasList[i];
            }
           
        }  
        return null;
    }

}
