using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.winCanvas = GetComponent<Canvas>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
