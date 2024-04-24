using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIPlayer : MonoBehaviour
{
    PlayerController player;
    TextMeshProUGUI textHealth;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        textHealth = GameObject.Find("TextHealth").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
       // textHealth.text = "" + player.Health;
    }
}
