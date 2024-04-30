using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Interact openFromInteraction;
    Canvas UICard;

    void Start(){
        UICard = GetComponentInChildren<Canvas>();
        UICard.gameObject.SetActive(false);
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
        UICard.gameObject.SetActive(true);
    }
}
