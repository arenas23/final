using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public Interact openFromInteraction;
    GameObject off;
    GameObject on;
    Canvas canvas;

    bool isOn = true;

    private void Awake()
    {
        canvas = GetComponentInChildren<Canvas>();
        off = canvas.transform.GetChild(0).gameObject;
        on = canvas.transform.GetChild(1).gameObject;
    }

    void Start()
    {
        on.SetActive(false);
    }

    private void OnEnable()
    {
        if (openFromInteraction)
        {
            openFromInteraction.GetInteractEvent.HasInteracted += Interact;
        }
    }

    private void OnDisable()
    {
        if (openFromInteraction)
        {
            openFromInteraction.GetInteractEvent.HasInteracted -= Interact;
        }
    }

    void Interact()
    {

        if (isOn)
        {
            off.SetActive(false);
            on.SetActive(true);
            isOn = false;
            GameManager.Instance.activeGenerators += 1;

        }

        if(GameManager.Instance.activeGenerators == 2)
        {
           
            Objjectives.Instance.ChangeObjective(Objjectives.Objectives.TURN_ON_GENERATORS_COMPLETED);
        }
    }
}
