using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Playerstats stats;
   
    // Start is called before the first frame update
    void Start()
    {
        stats.currenthealth = stats.maxhealth ;
    }
    
    public void TakeDamage(int damageAmount)
    {
        stats.currenthealth -= damageAmount;
        if(stats.currenthealth <= 0) 
        {
            Die();
        }
    }

    public void Die() 
    {
        SceneManager.LoadScene(4);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.L)) 
        {
            TakeDamage(10);
            
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            TakeDamage(-10);
        }

    }
}
