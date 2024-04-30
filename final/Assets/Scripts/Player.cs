using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    public LayerMask finalMask;

    [SerializeField] private Transform interactionPoint;
    private float interactionPointRadius = 7f;
    [SerializeField] private LayerMask interactableMask; 

    [SerializeField]private readonly Collider[] colliders = new Collider[3];
    [SerializeField] private int numCollidersFound;
    Interact interactable;
    Interact lastInteractable;


    // Update is called once per frame
    void Update()
    {
        VerifiedDistanceToItem();

   

        if (interactable) {
            if (Input.GetKeyDown(KeyCode.E)) PlayerInteract();
            interactable.CallView();
        }else {
            lastInteractable?.CallHideView();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionPointRadius);
    }

    public void PlayerInteract()
    {
        // RaycastHit hit;
        // Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));

        // if(Physics.Raycast(ray, out hit, 15, finalMask)){
        interactable.CallInteract(this);
        // }
    }

    public void VerifiedDistanceToItem()
    {
        numCollidersFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, colliders,interactableMask);
        if (numCollidersFound > 0)
        {
            interactable = colliders[0].GetComponent<Interact>();

        }else{

            lastInteractable = interactable;
            interactable = null;
        }
        // RaycastHit hit;
        // Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));

        // if (Physics.Raycast(ray, out hit, 20, finalMask))
        // {
        //     Debug.Log(hit.transform.name);
        //     Interact interactScript = hit.transform.GetComponent<Interact>();
        //     
        // }

        // 
    }

}
