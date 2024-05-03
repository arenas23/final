using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRobot : MonoBehaviour
{

    private AudioSource audioSource; 
    [SerializeField] private AudioClip audioClip; 
    public bool sonido = false;

    Vector3 currentPos;
    Vector3 lastPos;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        currentPos = transform.position;
        if (currentPos == lastPos)
        {

            audioSource.Stop();
            
        }
        else
        {
            audioSource.PlayOneShot(audioClip);
        }
        
        lastPos = transform.position;
    }
}
