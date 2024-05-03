using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectiveKeycard : MonoBehaviour
{
    bool isFirstTime = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && isFirstTime && Objjectives.Instance.currentObjective == (int)Objjectives.Objectives.GO_CONTROL_ROOM)
        {
            Objjectives.Instance.ChangeObjective(Objjectives.Objectives.SEARCH_KEYCARD);
            isFirstTime = false;
        }
    }
}
