using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) PlayerInteract();
    }

    public void PlayerInteract()
    {
        var finalMask = 1 << 8;

        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));

        if(Physics.Raycast(ray, out hit, 15, finalMask)){
            Interact interactScritp = hit.transform.GetComponent<Interact>();
            if(interactScritp) interactScritp.CallInteract(this);
        }

        
    }
    
}
