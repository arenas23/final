using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public Interact openFromInteraction;
    GameObject armed;
    GameObject disarmed;
    Canvas canvas;

    bool isArmed = true;

    private void Awake()
    {
        canvas = GetComponentInChildren<Canvas>();
        armed = canvas.transform.GetChild(0).gameObject;
        disarmed = canvas.transform.GetChild(1).gameObject;
    }

    void Start()
    {
        disarmed.SetActive(false);
    }

    private void OnEnable()
    {
        if (openFromInteraction)
        {
            openFromInteraction.GetInteractEvent.CanView += ShowDetails;
        }
    }

    private void OnDisable()
    {
        if (openFromInteraction)
        {
            openFromInteraction.GetInteractEvent.CanView -= ShowDetails;
        }
    }

    void ShowDetails()
    {
        if (isArmed)
        {
            armed.SetActive(false);
            disarmed.SetActive(true);
            isArmed = false;
            GameManager.Instance.activeGenerators += 1;
        }
    }
}
