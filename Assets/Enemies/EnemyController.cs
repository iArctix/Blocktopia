using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public EnemySettings settings;
    public Transform player;
    private float currentHealth;

    void Start()
    {
        currentHealth = settings.maxHealth;
    }

    void Update()
    {
       
    }

    
    public void TakeDamage(float damage)
    {
        
        currentHealth -= damage;

        
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            // For now, we'll just print a message to the console
            Debug.Log("Enemy took " + damage + " damage. Current health: " + currentHealth);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}