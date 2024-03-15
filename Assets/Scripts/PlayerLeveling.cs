using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLeveling : MonoBehaviour
{
    public Playerstats playerstats; // Reference to the PlayerStats Scriptable Object
    public int xpPerLevel = 100; // Amount of XP required for each level

    private void Start()
    {
       
    }

    private void Update()
    {
        // You might want to update the slider continuously if needed
        // UpdateSlider();
    }

    // Method to check for level up conditions
    public void CheckForLevelUp(int xpGained)
    {
        playerstats.playertotalexp += xpGained;

        // Check if the accumulated XP is enough for one or more level ups
        while (playerstats.playertotalexp >= playerstats.playerlevel * xpPerLevel)
        {
            LevelUp();
        }
    }

    // Method to level up the player
    private void LevelUp()
    {
        playerstats.playerlevel++;
        playerstats.skillpoints++;
    }

  
}