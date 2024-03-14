using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Playerstats stats;
    public PlayerHealth playerhealth;
    public Image healthBarFill;
    // Start is called before the first frame update
    void Start()
    {
        playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        healthBarFill.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float fillAmount = (float)playerhealth.currenthealth / stats.maxhealth;
        healthBarFill.fillAmount = fillAmount;
    }
}
