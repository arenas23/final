using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] Interact openFromInteraction;

    private Canvas UIShip;

    private void OnEnable()
    {
        if (openFromInteraction)
        {
            openFromInteraction.GetInteractEvent.HasInteracted += Interact;
            openFromInteraction.GetInteractEvent.CanView += ShowDetails;
            openFromInteraction.GetInteractEvent.HideView += HideDetails;
        }
    }

    private void OnDisable()
    {
        if (openFromInteraction)
        {
            openFromInteraction.GetInteractEvent.HasInteracted -= Interact;
            openFromInteraction.GetInteractEvent.CanView -= ShowDetails;
            openFromInteraction.GetInteractEvent.HideView -= HideDetails;
        }
    }

    void Start()
    {

        UIShip = GetComponentInChildren<Canvas>();
        UIShip.gameObject.SetActive(false);

    }

    void ShowDetails()
    {
        if(VerifyEscapeObjective())
        {
            UIShip.gameObject.SetActive(true);
        }
     
    }

    void Interact()
    {
        if (VerifyEscapeObjective())
        {
            GameManager.Instance.WinPlayer();

        }

    }

    void HideDetails()
    {
        UIShip.gameObject.SetActive(false);
    }

    private bool VerifyEscapeObjective(){
        if (Objjectives.Instance.currentObjective == (int) Objjectives.Objectives.ESCAPE)
        {
            return true;
        }else{
            return false;
        }
    }
}
