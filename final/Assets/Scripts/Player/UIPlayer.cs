using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class UIPlayer : MonoBehaviour
{
    PlayerController player;
    TextMeshProUGUI textHealth;
    public Image barraSalud;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        textHealth = GameObject.Find("TextHealth").GetComponent<TextMeshProUGUI>();
        barraSalud = GameObject.Find("Health").GetComponent<Image>();
    }
    void Update()
    {
       textHealth.text = "" + player.Health;
       HealthActuliaced();
    }

    void HealthActuliaced()
    {
        barraSalud.fillAmount = player.Health/100;
    }
}
