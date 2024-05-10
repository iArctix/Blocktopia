using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLeveling : MonoBehaviour
{
    public Playerstats playerstats; 
    public int xpPerLevel = 100; 

    public void CheckForLevelUp(int xpGained)
    {
        Debug.Log("XP: " + playerstats.playertotalexp + " + " + xpGained);

        // Calculate the total experience including the gained experience
        int totalExp = playerstats.playertotalexp + xpGained;

        // Calculate the remainder experience after deducting full levels
        int remainderExp = totalExp % 100;

        // Check if the player leveled up
        if (totalExp >= 100 && remainderExp < playerstats.playertotalexp % 100)
        {
            LevelUp();
        }

        // Update the total experience
        playerstats.playertotalexp = totalExp;

        Debug.Log("Remainder XP: " + remainderExp);
    }

    private void LevelUp()
    {
        playerstats.playerlevel++;
        playerstats.skillpoints++;
    }


}