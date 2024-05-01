using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    public Image open1, open2;
    public TextMeshProUGUI unlock1, unlock2;
    private bool canOpen = false;
    private bool isOpen = false;

    public void Start()
    {
        animator = GetComponentInParent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpen)
        {
            // Debug.Log("entre");
            animator.Play("abrir");
            isOpen = true;
            AudioManager.Instance.PlaySFX(1);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            open1.gameObject.SetActive(true);
            unlock1.gameObject.SetActive(false);
            open2.gameObject.SetActive(true);
            unlock2.gameObject.SetActive(false);
            canOpen = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            open1.gameObject.SetActive(false);
            unlock1.gameObject.SetActive(true);
            open2.gameObject.SetActive(false);
            unlock2.gameObject.SetActive(true);
            canOpen = false;
            if (isOpen)
            {
                animator.Play("cerrar");
                isOpen = false;
            }
        }
    }
}
