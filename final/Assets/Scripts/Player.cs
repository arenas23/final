using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public LayerMask finalMask;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) VerifiedDistanceToItem();
    }

    public void PlayerInteract()
    {


        // RaycastHit hit;
        // Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));

        // if(Physics.Raycast(ray, out hit, 15, finalMask)){
        //     Interact interactScritp = hit.transform.GetComponent<Interact>();
        //     if(interactScritp) interactScritp.CallInteract(this);
        // }
    }

    public void VerifiedDistanceToItem()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));

        if (Physics.Raycast(ray, out hit, 20, finalMask))
        {
            Debug.Log(hit.transform.name);
            Interact interactScript = hit.transform.GetComponent<Interact>();
            if (interactScript) interactScript.CallView();
        }

        Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);
    }

}
