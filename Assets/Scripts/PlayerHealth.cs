using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Playerstats stats;
    public GameObject hurtPanel; 

    // Start is called before the first frame update
    void Start()
    {
        stats.currenthealth = stats.maxhealth;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void TakeDamage(int damageAmount)
    {
        stats.currenthealth -= damageAmount;
        if (stats.currenthealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(ShowHurtEffect());
        }
    }

    IEnumerator ShowHurtEffect()
    {
        // Enable the red panel
        hurtPanel.SetActive(true);
        // Wait for a short duration
        yield return new WaitForSeconds(0.2f);
        // Disable the red panel
        hurtPanel.SetActive(false);
    }

    public void Die()
    {
        SceneManager.LoadScene(5);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            TakeDamage(-10);
        }
    }
}