using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Playerstats stats;
    public PlayerHealth playerhealth;
    [SerializeField] private Slider healthBar;
    [SerializeField] private Image healthfill;
    // Start is called before the first frame update
    void Start()
    {
        playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float fillAmount = playerhealth.currenthealth / stats.maxhealth;
        healthfill.fillAmount = fillAmount;
    }
}
