using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public EnemySettings settings;
    public Transform player;
    private float currentHealth;
    public PlayerLeveling playerLeveling;
    public InventoryData inventory;
    private PickupUI pickupUI;

    void Start()
    {
        currentHealth = settings.maxHealth;
        pickupUI = GameObject.Find("PickupUi").GetComponent<PickupUI>();
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
            playerLeveling.CheckForLevelUp(settings.exp);
            inventory.coins += settings.coins;
            pickupUI.DisplayPickup("XP", settings.exp);
            pickupUI.DisplayPickup("Coins", settings.coins);
           

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