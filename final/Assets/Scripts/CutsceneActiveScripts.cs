using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneActiveScripts : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject objectPoolingBalas;
    public GameObject canvasTemporizador;
    public GameObject player;


    private void OnEnable()
    {
        mainCamera.GetComponent<CameraController>().enabled = false;
        objectPoolingBalas.GetComponent<Weapon>().enabled = false;
        canvasTemporizador.GetComponent<Canvas>().enabled = false;
        player.GetComponent<PlayerController>().enabled = false;
    }

    private void OnDisable()
    {
        mainCamera.GetComponent<CameraController>().enabled = true;
        objectPoolingBalas.GetComponent<Weapon>().enabled = true;
        canvasTemporizador.GetComponent<Canvas>().enabled = true;
        player.GetComponent<PlayerController>().enabled = true;
    }
}
