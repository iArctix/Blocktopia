using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Settings", menuName = "Enemy/Settings")]
public class EnemySettings : ScriptableObject
{
    public float maxHealth = 100;
    public EnemyBehavior behavior = EnemyBehavior.Aggressive;
    public float attackRange = 2f;
    public float detectionRange = 10f; // Range at which the enemy detects the player
    public float roamingRadius = 10f; // Radius within which the enemy roam
    public float homeRegionRadius = 20f;

    public float damage = 10f;

    //Rewards
    public int coins;
    public int exp;

    // Add more customizable properties as needed
}

public enum EnemyBehavior
{
    Passive,
    Neutral,
    Aggressive
}
