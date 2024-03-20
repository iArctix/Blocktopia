using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUi : MonoBehaviour
{
    public TextMeshProUGUI health;
    public Playerstats stats;

    void Update()
    {
        health.text = "Health: " + stats.currenthealth + " / " + stats.maxhealth;
    }
}
