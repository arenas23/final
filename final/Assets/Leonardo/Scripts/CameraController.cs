using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 80f;
    public Transform playerBody;
    public GameObject player;
    float xRotation = 0;
    
    void Start()
    {
        player = GameObject.Find("Player");
        playerBody = player.GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        playerBody.Rotate(Vector3.up * mouseX);
        
    }
}
