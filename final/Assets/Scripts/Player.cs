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
        var layerMask0 = 1 << 0;
        var layerMask3 = 1 << 3;
        var finalMask = layerMask0 | layerMask3;

        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));

        if(Physics.Raycast(ray, out hit, 15, finalMask)){
            Interact interactScritp = hit.transform.GetComponent<Interact>();
            if(interactScritp) interactScritp.CallInteract(this);
        }

        
    }
    
}
